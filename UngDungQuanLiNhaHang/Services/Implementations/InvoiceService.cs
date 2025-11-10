using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class InvoiceService(InvoiceRepo invoiceRepo,
        TransactionRepo transactionRepo,
        ProductRepo productRepo,
        ProductOptionRepo productOptionRepo,
        CartRepo cartRepo,
        EmployeeRepo employeeRepo,
        BookTableRepo bookTableRepo,
        IVnPayService vnPayService,
        
        IEmailService emailService,
        IOrderNotificationService orderNotificationService
        ) : IInvoiceServices {

        private static string BuildInvoiceEmailBody(Invoices invoices) {
            var sb = new StringBuilder();

            sb.Append($@"
        <div style='font-family: Arial, sans-serif; line-height: 1.6'>
            <h2 style='color:#4CAF50;'>Cảm ơn bạn đã đặt hàng!</h2>
            <p>Đơn hàng <b>#{invoices.InvoiceId}</b> của bạn đã được tiếp nhận thành công.</p>

            <h3>Chi tiết đơn hàng:</h3>
            <table style='width:100%; border-collapse: collapse;'>
                <thead>
                    <tr style='background-color:#f2f2f2;'>
                        <th style='border:1px solid #ddd; padding:8px;'>Sản phẩm</th>
                        <th style='border:1px solid #ddd; padding:8px;'>Số lượng</th>
                        <th style='border:1px solid #ddd; padding:8px;'>Giá</th>
                        <th style='border:1px solid #ddd; padding:8px;'>Thành tiền</th>
                    </tr>
                </thead>
                <tbody>
    ");

            foreach ( var item in invoices.invoiceItems ) {
                var productName = item.Products?.ProductName ?? "Sản phẩm";
                var totalPrice = item.Quantity * item.Price;
                sb.Append($@"
            <tr>
                <td style='border:1px solid #ddd; padding:8px;'>{productName}</td>
                <td style='border:1px solid #ddd; padding:8px; text-align:center;'>{item.Quantity}</td>
                <td style='border:1px solid #ddd; padding:8px; text-align:right;'>{item.Price:N0} đ</td>
                <td style='border:1px solid #ddd; padding:8px; text-align:right;'>{totalPrice:N0} đ</td>
            </tr>
        ");
                if ( item.orderItemOptions != null && item.orderItemOptions.Any() ) {
                    sb.Append("<tr><td colspan='4'>");
                    sb.Append(@"
            <div style='margin-top:16px; padding-top:16px; border-top:1px solid #e0e0e0;'>
                <p style='font-weight:600; margin-bottom:8px; color:#1976d2; font-size:14px;'>Tùy chọn thêm:</p>
        ");

                    foreach ( var opt in item.orderItemOptions ) {
                        var optionTotal = opt.Price * opt.Quantity;

                        sb.Append($@"
                <div style='margin-bottom:12px; padding:12px; background-color:#f5f5f5; border-radius:6px;'>
                    <p style='font-weight:600; margin:0 0 6px 0; font-size:13px;'>{opt.OrderItemOptionName}</p>

                    <div style='display:flex; justify-content:space-between; margin-bottom:4px;'>
                        <span style='color:#666; font-size:12px;'>Số lượng:</span>
                        <span style='font-size:12px; font-weight:500;'>x{opt.Quantity}</span>
                    </div>

                    <div style='display:flex; justify-content:space-between; margin-bottom:4px;'>
                        <span style='color:#666; font-size:12px;'>Giá:</span>
                        <span style='font-size:12px; font-weight:500;'>{opt.Price:N0}đ</span>
                    </div>

                    <div style='display:flex; justify-content:space-between;'>
                        <span style='color:#666; font-size:12px;'>Thành tiền:</span>
                        <span style='font-size:12px; font-weight:600; color:#d32f2f;'>{optionTotal:N0}đ</span>
                    </div>
                </div>
            ");
                    }

                    sb.Append("</div></td></tr>");
                }
            }

            sb.Append($@"
                </tbody>
            </table>
            <h3 style='text-align:right; color:#e91e63;'>Tổng cộng: {invoices.TotalAmount:N0} đ</h3>

            <p><b>Địa chỉ giao hàng:</b> {invoices.address?.Province}, {invoices.address?.District}</p>
            <p><b>Phương thức thanh toán:</b> {invoices.PaymentMethod?.PaymentMethodName}</p>

            <hr/>
            <p style='font-size:14px;'>Nếu bạn có bất kỳ thắc mắc nào, vui lòng liên hệ bộ phận hỗ trợ của chúng tôi.</p>
        </div>
    ");

            return sb.ToString();
        }

        // them mon an vao hoa don tai cua hang
        public async Task<ApiResponse<bool>> AddInvoiceItem(int employeeId, InvoiceOffLineDTO invoiceDTO) {
            bool isEmployeeExists = await employeeRepo.IsEmployeeExists(employeeId);
            if ( !isEmployeeExists ) {
                return ApiResponse<bool>.FailResponse("Nhân viên không tồn tại.");
            }

            var invoice = await invoiceRepo.GetByInvoiceIdForAddItem(invoiceDTO.invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if ( invoice.InvoiceStatusId > 2 ) {
                return ApiResponse<bool>.FailResponse("Chỉ có thể thêm sản phẩm vào hóa đơn đã xác nhận.");
            }
            invoice.TotalAmount += invoice.TotalAmount;
            invoice.TotalQuantity += invoice.TotalQuantity;
            try {
                await transactionRepo.BeginTransactionAsync();
                foreach (var item in invoiceDTO.invoiceItems) {
                    var product = await productRepo.GetProductById(item.productId);
                    if ( product == null )
                        return ApiResponse<bool>.FailResponse("Dữ liệu product  không hợp lệ.");
                    var invoiceItem = invoice.invoiceItems.FirstOrDefault(s => s.ProductId == item.productId);
                    if ( invoiceItem == null ) {
                        InvoiceItems items = new InvoiceItems() {
                            Quantity = item.quantity,
                            Price = item.price,
                            ProductId = item.productId,
                            InvoiceId = invoice.InvoiceId,
                        };
                        product.Quantity -= items.Quantity;
                        if ( item.orderOptions.Any() ) {
                            foreach ( var i in item.orderOptions ) {
                                var productOption = await productOptionRepo.GetById(i.productOptionId);
                                if ( productOption == null ) {
                                    return ApiResponse<bool>.FailResponse("Dữ liệu option  không hợp lệ.");
                                }
                                if ( i.quantity > productOption.OptionValue ) {
                                    return ApiResponse<bool>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                                }
                                OrderItemOption order = new OrderItemOption() {
                                    OrderItemOptionName = productOption.OptionName,
                                    Price = productOption.Price,
                                    Quantity = i.quantity,
                                    productOptionId = productOption.ProductOptionId,
                                    InvoiceItem = items

                                };
                                items.orderItemOptions.Add(order);
                                // cap nhat lai so luong option trong kho
                                productOption.OptionValue -= i.quantity;
                                invoice.TotalAmount += i.quantity * productOption.Price;
                            }
                        }
                        // them InvoiceItem vao hoa don
                        invoice.invoiceItems.Add(items);
                       
                    }
                    else {

                        if ( item.quantity > 0 ) {
                            invoiceItem.Quantity += item.quantity;
                            product.Quantity -= item.quantity;
                            invoice.TotalAmount += item.price * item.quantity;
                        }
                        if ( item.orderOptions.Any() ) {
                            foreach ( var i in item.orderOptions ) {
                                var productOption = await productOptionRepo.GetById(i.productOptionId);
                                if ( productOption == null ) {
                                    return ApiResponse<bool>.FailResponse("Dữ liệu option  không hợp lệ.");
                                }
                                if ( i.quantity > productOption.OptionValue ) {
                                    return ApiResponse<bool>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                                }

                                var orderItemOption = invoiceItem.orderItemOptions
                                    .FirstOrDefault(s => s.productOptionId == productOption.ProductOptionId);
                                if ( orderItemOption == null ) {
                                    OrderItemOption order = new() {
                                        OrderItemOptionName = productOption.OptionName,
                                        Quantity = i.quantity,
                                        Price = productOption.Price,
                                        InvoiceItemId = invoiceItem.InvoiceItemId,
                                        productOptionId = productOption.ProductOptionId

                                    };
                                    invoiceItem.orderItemOptions.Add(order);

                                }
                                else {
                                    orderItemOption.Quantity += i.quantity;
                                }
                                productOption.OptionValue -= i.quantity;
                               
                            }
                        }

                    }
                }
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception e ) {
                await transactionRepo.RollbackAsync();
                Debug.WriteLine("AddInvoiceItem Error:" + e.ToString());

                return ApiResponse<bool>.FailResponse("Loi khi them mon an vao hoa don");
            }
        }

        public async Task<ApiResponse<bool>> CancellInvoiceForCustomer(int customerId, int invoiceId) {
            var invoice = await invoiceRepo.GetByCustomerIdAndInvoiceIdForCancell(customerId, invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if ( invoice.InvoiceStatusId != 1 ) {
                return ApiResponse<bool>.FailResponse("Chỉ có thể hủy hóa đơn đang chờ xử lý.");
            }
            invoice.InvoiceStatusId = 5; // trạng thái hủy

            try {
                await transactionRepo.BeginTransactionAsync();
                var cart = await cartRepo.GetCart(customerId);
                if ( cart != null ) {
                    // rollback lai san pham trong gio hang
                    foreach ( var item in invoice.invoiceItems ) {
                        var cartItem = cart.CartItems.Where(s => s.ProductId == item.ProductId).FirstOrDefault();
                        if ( cartItem != null ) {
                            cartItem.Quantity += item.Quantity;
                        }
                        else {
                            CartItems newCartItem = new CartItems() {
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.Price,
                                Carts = cart
                            };
                            cart.CartItems.Add(newCartItem);
                        }
                    }

                    cartRepo.UpdateCart(cart);
                }

                // cap nhat lai so luong san pham trong kho
                foreach ( var item in invoice.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.ProductId);
                    if ( product != null ) {
                        product.Quantity += item.Quantity;
                    }
                    // cap nhat lai so luong option trong kho
                    if ( item.orderItemOptions != null && item.orderItemOptions.Any() ) {
                        foreach ( var option in item.orderItemOptions ) {
                            var productOption = await productOptionRepo.GetById(option.OrderItemOptionId);
                            if ( productOption != null ) {
                                productOption.OptionValue += option.Quantity;
                            }
                        }
                    }
                }
                invoiceRepo.UpdateInvoice(invoice);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi hủy hóa đơn." + ex.Message);
            }
        }
        public async Task<ApiResponse<bool>> CancellInvoiceOfflineForStaff(int employeeId, int invoiceId) {
            bool isEmployeeExists = await employeeRepo.IsEmployeeExists(employeeId);
            if ( !isEmployeeExists ) {
                return ApiResponse<bool>.FailResponse("Nhân viên không tồn tại.");
            }

            var invoice = await invoiceRepo.GetByInvoiceIdForCancell(invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if ( invoice.InvoiceStatusId != 1 ) {
                return ApiResponse<bool>.FailResponse("Chỉ có thể hủy hóa đơn đang chờ xử lý.");
            }
            invoice.InvoiceStatusId = 5; // trạng thái hủy

            invoice.employeeId = employeeId; // nhan vien thuc hien huy hoa don
            try {
                await transactionRepo.BeginTransactionAsync();

                // cap nhat lai so luong san pham trong kho
                foreach ( var item in invoice.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.ProductId);
                    if ( product != null ) {
                        product.Quantity += item.Quantity;
                    }
                    // cap nhat lai so luong option trong kho
                    if ( item.orderItemOptions != null && item.orderItemOptions.Any() ) {
                        foreach ( var option in item.orderItemOptions ) {
                            var productOption = await productOptionRepo.GetById(option.OrderItemOptionId);
                            if ( productOption != null ) {
                                productOption.OptionValue += option.Quantity;
                            }
                        }
                    }
                }
                invoiceRepo.UpdateInvoice(invoice);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi hủy hóa đơn." + ex.Message);
            }
        }

        public async Task CancellInvoiceOnlineForStaff(int invoiceId) {
            var invoice = await invoiceRepo.GetByInvoiceIdForCancell(invoiceId);
            if ( invoice == null ) {
                return;
            }
            if ( invoice.IsPayment == true ) {
                return;
            }
            invoice.InvoiceStatusId = 5; // trạng thái hủy
            if ( invoice.customerId == null ) {
                return;
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                var cart = await cartRepo.GetCart(invoice.customerId ?? 0);
                if ( cart != null ) {
                    // rollback lai san pham trong gio hang
                    foreach ( var item in invoice.invoiceItems ) {
                        var cartItem = cart.CartItems.Where(s => s.ProductId == item.ProductId).FirstOrDefault();
                        if ( cartItem != null ) {
                            cartItem.Quantity += item.Quantity;
                        }
                        else {
                            CartItems newCartItem = new CartItems() {
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.Price,
                                Carts = cart
                            };
                            cart.CartItems.Add(newCartItem);
                        }
                    }

                    cartRepo.UpdateCart(cart);
                }

                // cap nhat lai so luong san pham trong kho
                foreach ( var item in invoice.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.ProductId);
                    if ( product != null ) {
                        product.Quantity += item.Quantity;
                    }
                    // cap nhat lai so luong option trong kho
                    if ( item.orderItemOptions != null && item.orderItemOptions.Any() ) {
                        foreach ( var option in item.orderItemOptions ) {
                            var productOption = await productOptionRepo.GetById(option.OrderItemOptionId);
                            if ( productOption != null ) {
                                productOption.OptionValue += option.Quantity;
                            }
                        }
                    }
                }
                invoiceRepo.UpdateInvoice(invoice);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return;
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                Console.WriteLine("Lỗi khi hủy hóa đơn." + ex.Message);
                return;
            }
        }
        // khach hang online dat hang va thanh toan khi nhan hang
        public async Task<ApiResponse<bool>> CreateInvoiceCustomer(int customerId, InvoiceDTO invoiceDTO) {
            if ( invoiceDTO == null ) {
                return ApiResponse<bool>.FailResponse("Invalid invoice data.");
            }
            // kiem tra so luong tung san pham 
            foreach ( var item in invoiceDTO.invoiceItems ) {

                if ( item == null || item.quantity <= 0 || item.price <= 0 ) {
                    return ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ");
                }

            }
            // kiem tra cart 
            var carts = await cartRepo.GetCartByCustomerId(customerId);
            if ( carts == null  ) {
                return ApiResponse<bool>.FailResponse("Cart not found");
            }

            // tao hoa don
            Invoices invoices = new();
            invoices.customerId = customerId;
            invoices.AddressId = invoiceDTO.addressId;
            invoices.PaymentMethodId = invoiceDTO.paymentMethodId;
            invoices.TotalQuantity = invoiceDTO.totalQuantity;
            invoices.TotalAmount = invoiceDTO.totalAmount;
            invoices.IsPayment = invoiceDTO.isPayment;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = false;
            invoices.Create_At = DateTime.Now;
           
            try {

                await transactionRepo.BeginTransactionAsync();
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    var cartItem = carts.CartItems.FirstOrDefault(s => s.ProductId == item.productId);
                    if (cartItem == null) {
                        await transactionRepo.RollbackAsync();
                        return ApiResponse<bool>.FailResponse("Sản phẩm không tồn tại trong giỏ hàng.");
                    }
                    
                    var product = await productRepo.GetProductById(item.productId);
                    if ( product == null || item.quantity > product.Quantity ) {
                        await transactionRepo.RollbackAsync();
                        return ApiResponse<bool>.FailResponse("Sản phẩm không đủ số lượng");
                    }
                    product.Quantity -= item.quantity;
                    // tao invoice item
                    InvoiceItems items = new InvoiceItems() {
                        Quantity = item.quantity,
                        Price = item.price,
                        ProductId = item.productId,
                        
                    };

                    // kiem tra ton tai cua  item.productOptions 
                    if ( item.orderOptions != null && item.orderOptions.Any() ) {

                        foreach ( var i in item.orderOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.productOptionId);
                            if ( productOption == null ) {
                                await transactionRepo.RollbackAsync();
                                return ApiResponse<bool>.FailResponse("ProductOption không hợp lệ." + i.productOptionId.ToString() + i.quantity.ToString());
                            }
                            if ( i.quantity > productOption.OptionValue ) {
                                await transactionRepo.RollbackAsync();
                                return ApiResponse<bool>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                            }
                            OrderItemOption invoiceItemOptions = new OrderItemOption() {
                                OrderItemOptionName = productOption.OptionName,
                                Quantity = i.quantity,
                                Price = productOption.Price,
                                InvoiceItem = items,
                                productOptionId = productOption.ProductOptionId
                            };
                            productOption.OptionValue -= item.quantity;
                            invoices.TotalAmount += i.quantity * productOption.Price;
                            items.orderItemOptions.Add(invoiceItemOptions);

                        }
                    }
                    
                    // them InvoiceItem vao hoa don
                    invoices.invoiceItems.Add(items);
                }
                await invoiceRepo.AddInvoice(invoices);



                
                carts.TotalAmount -= invoiceDTO.totalAmount;

                var itemsCopy = carts.CartItems.ToList();
                foreach ( var item in itemsCopy ) {

                    if ( item != null ) {
                        
                        carts.CartItems.Remove(item);
                    }
                }


                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                // gui mail cho khach hang khi dat hang
                BackgroundJob.Schedule<IEmailService>(x => x.SendEmailAsync(
                    "ntam74143@gmail.com",
                    "Đặt đơn hàng thành công.",
                    BuildInvoiceEmailBody(invoices)
                ), TimeSpan.FromMinutes(2));
                var respon = new InvoiceForAdminResponse {
                    invoiceId = invoices.InvoiceId,
                    totalAmount = invoices.TotalAmount,
                    isPayment = invoices.IsPayment,
                    invoiceType = invoices.InvoiceType,
                    create_At = invoices.Create_At.ToString("HH:mm dd/MM/yyyy"),
                };
                // thong bao don hang moi den admin
                await orderNotificationService.NotifyNewOrder(respon);
                return ApiResponse<bool>.SuccessResponse(true, "Đặt hàng thành công.");


            }
            catch ( Exception  ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.ToString());
            }
        }
        // tao hoa don offline cho khach hang dat ban
        public async Task<ApiResponse<bool>> CreateInvoiceForBookTable(int employeeId, InvoiceOffLineDTO invoiceDTO) {
            var bookTable = await bookTableRepo.GetBookTableByDate(DateTime.Now, invoiceDTO.tableId,invoiceDTO.customerId);
            if ( bookTable == null ) {
                return ApiResponse<bool>.FailResponse("Bàn chưa được đặt.");
            }
            if ( invoiceDTO == null ) {
                return ApiResponse<bool>.FailResponse("Invalid invoice data.");
            }

            // kiem tra so luong tung san pham 
            foreach ( var item in invoiceDTO.invoiceItems ) {
                if ( item == null || item.quantity <= 0 || item.price <= 0 ) {
                    return ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ");
                }
            }
            // tao hoa don
            Invoices invoices = new ();
            invoices.TotalQuantity = invoiceDTO.totalQuantity;
            // tru di so tien coc DepositAmount
            invoices.TotalAmount = invoiceDTO.totalAmount - bookTable.DepositAmount;
            invoices.IsPayment = false;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = true;
            invoices.Create_At = DateTime.Now;
            invoices.employeeId = employeeId;
            invoices.tableId = invoiceDTO.tableId;
            invoices.customerId = bookTable.customerId;
            invoices.AddressId = 1;
            invoices.PaymentMethodId = 3;
            try {
                await transactionRepo.BeginTransactionAsync();
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.productId);
                    if ( product == null ) {
                        return ApiResponse<bool>.FailResponse("Sản phẩm   không tồn tại");
                    }
                    if ( item.quantity > product.Quantity ) {
                        return ApiResponse<bool>.FailResponse($"Số lượng sản phẩm {product.ProductName} vượt quá số lượng trong kho.");
                    }
                    product.Quantity -= item.quantity;
                    // kiem tra san pham co ton tai trong gio hang hay khong
                }
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    // tao invoice item
                    InvoiceItems items = new InvoiceItems() {
                        Quantity = item.quantity,
                        Price = item.price,
                        ProductId = item.productId,
                        Invoices = invoices
                    };
                    // kiem tra ton tai cua  item.productOptions 
                    if ( item.orderOptions != null && item.orderOptions.Count() > 0 ) {
                        foreach ( var i in item.orderOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.productOptionId);
                            if ( productOption == null )
                                return ApiResponse<bool>.FailResponse("ProductOption không hợp lệ.");
                            if ( i.quantity > productOption.OptionValue )
                                return ApiResponse<bool>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                            // them invoiceItemOption
                            OrderItemOption invoiceItemOptions = new OrderItemOption() {
                                OrderItemOptionName = productOption.OptionName,
                                Quantity = i.quantity,
                                Price = productOption.Price,
                                InvoiceItem = items,
                                productOptionId = productOption.ProductOptionId

                            };
                            // cap nhat lai so luong option
                            productOption.OptionValue -= i.quantity;
                            items.orderItemOptions.Add(invoiceItemOptions);

                        }
                    }
                    // them InvoiceItem vao hoa don
                    invoices.invoiceItems.Add(items);
                }
                // them hoa don
                await invoiceRepo.AddInvoice(invoices);
                await transactionRepo.CompleteAsync();


                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
            }
        }

        // tao hoa don offline cho khach hang tai quan
        public async Task<ApiResponse<bool>> CreateInvoiceForOffLine(int employeeId, InvoiceOffLineDTO invoiceDTO) {
            var table = await bookTableRepo.GetTableById(invoiceDTO.tableId);
            if (table == null || table.Status == true) {
                return ApiResponse<bool>.FailResponse("Bàn không hợp lệ hoặc không có sẵn.");
            }
            if ( invoiceDTO == null ) {
                return ApiResponse<bool>.FailResponse("Invalid invoice data.");
            }
            // kiem tra so luong tung san pham 
            foreach ( var item in invoiceDTO.invoiceItems ) {
                if ( item == null || item.quantity <= 0 || item.price <= 0 ) {
                    return ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ");
                }
            }
            // tao hoa don
            Invoices invoices = new Invoices();
            invoices.TotalQuantity = invoiceDTO.invoiceItems.Count;
            invoices.TotalAmount = invoiceDTO.totalAmount;
            invoices.IsPayment = false;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = true;
            invoices.tableId = invoiceDTO.tableId;
            invoices.Create_At = DateTime.Now;
            invoices.employeeId = employeeId;
            invoices.PaymentMethodId = 4;
            invoices.AddressId = 1;      // tai quan nen mac dinh dia chi la 1
            try {
                await transactionRepo.BeginTransactionAsync();
                table.Status = true; // dat ban khong cho dat nua chi cho goi them 
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.productId);
                    if ( product == null ) {
                        return ApiResponse<bool>.FailResponse("Sản phẩm   không tồn tại");
                    }
                    if ( item.quantity > product.Quantity ) {
                        return ApiResponse<bool>.FailResponse($"Số lượng sản phẩm {product.ProductName} vượt quá số lượng trong kho.");
                    }
                    product.Quantity -= item.quantity;
                    
                }
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    // tao invoice item
                    InvoiceItems items = new InvoiceItems() {
                        Quantity = item.quantity,
                        Price = item.price,
                        ProductId = item.productId,
                       
                    };
                    // kiem tra ton tai cua  item.productOptions 
                    if ( item.orderOptions != null && item.orderOptions.Any() ) {
                        foreach ( var i in item.orderOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.productOptionId);
                            if ( productOption == null )

                                return ApiResponse<bool>.FailResponse("ProductOption không hợp lệ.");
                            if ( i.quantity > productOption.OptionValue )
                                return ApiResponse<bool>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                            // them invoiceItemOption
                            OrderItemOption invoiceItemOptions = new OrderItemOption() {
                                OrderItemOptionName = productOption.OptionName,
                                Quantity = i.quantity,
                                Price = productOption.Price,
                                InvoiceItem = items,
                                productOptionId = productOption.ProductOptionId
                            };
                            // cap nhat lai so luong option
                            productOption.OptionValue -= i.quantity;
                            // cap nhat lai tong tien cua hoa don
                            invoices.TotalAmount += i.quantity * productOption.Price;

                            items.orderItemOptions.Add(invoiceItemOptions);

                        }
                    }
                    // them InvoiceItem vao hoa don
                    invoices.invoiceItems.Add(items);
                }
                // them hoa don
                await invoiceRepo.AddInvoice(invoices);
                await transactionRepo.CompleteAsync();


                await transactionRepo.CommitAsync();


                var respon = new InvoiceForAdminResponse {
                    invoiceId = invoices.InvoiceId,
                    totalAmount = invoices.TotalAmount,
                    isPayment = invoices.IsPayment,
                    invoiceType = invoices.InvoiceType,
                    create_At = invoices.Create_At.ToString("HH:mm dd/MM/yyyy"),
                };
                // thong bao don hang moi den admin
                await orderNotificationService.NotifyNewOrder(respon);
                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
            }
        }

        // Hoa don online cho khach hang kem voi thanh toan online
        public async Task<ApiResponse<InvoideForPaymentResponse>> CreateInvoiceForOnline(int customerId, InvoiceDTO invoiceDTO,HttpContext httpContext) {
            // kiem tra du lieu
            if ( invoiceDTO == null ) {
                return ApiResponse<InvoideForPaymentResponse>.FailResponse("Invalid invoice data.");
            }
            // kiem tra so luong tung san pham 
            foreach ( var item in invoiceDTO.invoiceItems ) {

                if ( item == null || item.quantity <= 0 || item.price <= 0 ) {
                    return ApiResponse<InvoideForPaymentResponse>.FailResponse("Dữ liệu không hợp lệ");
                }

            }
            // kiem tra cart 
            var carts = await cartRepo.GetCart(customerId);

            if ( carts == null || carts.CartItems.Count == 0 ) {
                return ApiResponse<InvoideForPaymentResponse>.FailResponse("Customer not found");
            }


            // tao hoa don
            Invoices invoices = new Invoices();
            invoices.customerId = customerId;
            invoices.AddressId = invoiceDTO.addressId;
            invoices.PaymentMethodId = invoiceDTO.paymentMethodId;

            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum(s => s.quantity * s.price);
            invoices.IsPayment = false;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = false;
            invoices.Create_At = DateTime.Now;
            string url;
            try {
                await transactionRepo.BeginTransactionAsync();
                // xoa san pham trong gio hang va cap nhat so luong san pham
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    var product = await productRepo.GetProductById(item.productId);
                    if ( product == null ) {
                        return ApiResponse<InvoideForPaymentResponse>.FailResponse("Sản phẩm   không tồn tại");
                    }
                    if ( item.quantity > product.Quantity ) {
                        return ApiResponse<InvoideForPaymentResponse>.FailResponse($"Số lượng sản phẩm {product.ProductName} vượt quá số lượng trong kho.");
                    }
                    product.Quantity -= item.quantity;
                    // kiem tra san pham co ton tai trong gio hang hay khong
                    var cartitem = carts.CartItems.Where(s => s.ProductId == item.productId).FirstOrDefault();
                    if ( cartitem == null ) {
                        return ApiResponse<InvoideForPaymentResponse>.FailResponse("Sản phẩm không tồn tại trong giỏ hàng");
                    }
                    

                }
                
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    // tao invoice item
                    InvoiceItems items = new InvoiceItems() {
                        Quantity = item.quantity,
                        Price = item.price,
                        ProductId = item.productId,
                        Invoices = invoices
                    };
                    // kiem tra ton tai cua  item.productOptions 
                    if ( item.orderOptions != null && item.orderOptions.Any() ) {
                        foreach ( var i in item.orderOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.productOptionId);
                            if ( productOption == null )
                                return ApiResponse<InvoideForPaymentResponse>.FailResponse("ProductOption không hợp lệ.");
                            if ( i.quantity > productOption.OptionValue )
                                return ApiResponse<InvoideForPaymentResponse>.FailResponse("Số lượng option vượt quá số lượng trong kho.");
                            // them invoiceItemOption
                            OrderItemOption invoiceItemOptions = new OrderItemOption() {
                                OrderItemOptionName = productOption.OptionName,
                                Quantity = i.quantity,
                                Price = productOption.Price,
                                InvoiceItem = items,
                                productOptionId = productOption.ProductOptionId
                            };
                            // cap nhat lai so luong option
                            productOption.OptionValue -= i.quantity;
                            // cap nhat lai tong tien cua hoa don
                            invoices.TotalAmount += i.quantity * productOption.Price;

                            items.orderItemOptions.Add(invoiceItemOptions);

                        }
                    }
                    
                    // them InvoiceItem vao hoa don
                    invoices.invoiceItems.Add(items);
                }
                // them hoa don
                await invoiceRepo.AddInvoice(invoices);
                await transactionRepo.CompleteAsync();

                PaymentInformationModel model = new PaymentInformationModel();
                model.orderId = invoices.InvoiceId;
                model.Amount = invoices.TotalAmount;
                model.customerId = customerId.ToString();
                model.OrderType = "False";
                
                url = vnPayService.CreatePaymentUrl(model, httpContext, "http://localhost:5030/api/VnPay/PaymentCallbackVnpay", invoices.InvoiceId);
                var response = new InvoideForPaymentResponse {
                    invoiceId = invoices.InvoiceId,
                    url = url,
                };
                // sap xep 15 phut neu khach hang khong thanh toan thi huy hoa don
                BackgroundJob.Schedule<IInvoiceServices>(x => x.CancellInvoiceOnlineForStaff(invoices.InvoiceId), TimeSpan.FromMinutes(15));
                await transactionRepo.CommitAsync();
                return ApiResponse<InvoideForPaymentResponse>.SuccessResponse(response);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<InvoideForPaymentResponse>.FailResponse("Lỗi khi thêm hóa đơn." + ex.ToString());
            }
        }

        public async Task<ApiResponse<List<InvoiceForCustomerResponse>>> GetInvoicesByCustomerId(int customerId) {
            var invoices = await invoiceRepo.GetInvoicesByCustomerId(customerId);
            if ( invoices == null || invoices.Count == 0 ) {
                return ApiResponse<List<InvoiceForCustomerResponse>>.FailResponse("No invoices found for the customer.");
            }
            if ( invoices.Any(i => i.invoiceItems == null || i.invoiceItems.Count == 0) ) {
                return ApiResponse<List<InvoiceForCustomerResponse>>.FailResponse("Some invoices have no items.");
            }
            if ( invoices.Any(i => i.invoiceItems.Any(ii => ii.Products == null)) ) {
                return ApiResponse<List<InvoiceForCustomerResponse>>.FailResponse("Some invoice items have no associated products.");
            }
            var response = invoices.Select(i => new InvoiceForCustomerResponse {
                invoiceId = i.InvoiceId,
                totalAmount = i.TotalAmount,
                create_At = i.Create_At,
                invoiceStatusId = i.InvoiceStatusId,
                invoiceItems = i.invoiceItems.Select(ii => new InvoiceItemResponse {
                    productId = ii.ProductId,
                    productName = ii.Products != null ? ii.Products.ProductName : "Dữ liệu lỗi. Vui lòng thử lại sao ",
                    quantity = ii.Quantity,
                    price = ii.Price,
                    productImage = ii.Products != null ? ( ii.Products.images != null ?  ii.Products.images.First().ImagesUrl   : "Img" ) : "Img",
                    options = ii.orderItemOptions != null ? ii.orderItemOptions.Select(oio => new InvoiceItemOptionRespon {
                        optionName = oio.OrderItemOptionName,
                        quantity = oio.Quantity,
                        price = oio.Price
                    }).ToList() : new List<InvoiceItemOptionRespon>()
                }).ToList()
            }).ToList();
            return ApiResponse<List<InvoiceForCustomerResponse>>.SuccessResponse(response);
        }

        public async Task<ApiResponse<bool>> UpdateActiveInvoice(int invoiceId, int statusId,int employeeId) {
            var invoice = await invoiceRepo.GetByInvoiceId(invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if (invoice.InvoiceStatusId == 5 || invoice.InvoiceStatusId == 6) {
                return ApiResponse<bool>.FailResponse("Hóa đơn đã bị hủy hoặc hoàn thành, không thể cập nhật trạng thái.");
            }
            
            if ( statusId <= 0 || statusId > 6 || statusId <= invoice.InvoiceStatusId ) {
                return ApiResponse<bool>.FailResponse("Trạng thái không hợp lệ");
            }
           
            try {   
                await transactionRepo.BeginTransactionAsync();
                if ( statusId == 4 ) {
                    if ( invoice.tableId != null ) {
                        var table = await bookTableRepo.GetTableById(invoice.tableId ?? 0);
                        if (table== null)
                            return ApiResponse<bool>.FailResponse("Khoong co table");
                        if ( table != null && ( statusId == 4 || statusId == 5 || statusId == 6 ) ) {
                            table.Status = false; // khi hoa don bi huy hoac hoan thanh thi tra trang thai ban ve con trong
                            bookTableRepo.UpdateTable(table);
                        }
                    }
                    invoice.IsPayment = true;
                }
                invoice.InvoiceStatusId = statusId;
                invoice.employeeId = employeeId;
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật trạng thái hóa đơn thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi cập nhật trạng thái hóa đơn." + ex.Message);

            }
        }
        public async Task<ApiResponse<PageResponse<InvoiceForAdminResponse>>> GetAllInvoicesByDayAndStatusId(DateTime Date, int page = 1, int status = 1) {
            int pageSize = 12;
            var invoices = await invoiceRepo.GetAllInvoicesByDateAndStatusId(Date, status);
            if ( invoices == null || invoices.Count == 0 ) {
                return ApiResponse<PageResponse<InvoiceForAdminResponse>>.SuccessResponse(new PageResponse<InvoiceForAdminResponse>(),"Không có hóa đơn nào trong hôm nay.");
            }
            var pagedInvoices = invoices
                .Skip(( page - 1 ) * pageSize)
                .Take(pageSize)
                .ToList();
            var response = pagedInvoices.Select(i => new InvoiceForAdminResponse {
                invoiceId = i.InvoiceId,
                totalAmount = i.TotalAmount,
                totalQuantity = i.TotalQuantity,
                isPayment = i.IsPayment,
                invoiceType = i.InvoiceType,
                invoiceStatusId = i.InvoiceStatusId,
                invoiceStatusName = i.InvoiceStatus != null ? i.InvoiceStatus.InvoiceStatusName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                create_At = i.Create_At.ToString("HH:mm dd/MM/yyyy"),
                paymentMethodName = i.PaymentMethod != null ? i.PaymentMethod.PaymentMethodName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                employeeId = i.employeeId,
            });
            var pageResponse = new PageResponse<InvoiceForAdminResponse> {
               page = page,
               pageSize = pageSize,
               totalItems = invoices.Count,
               totalPages = (int)Math.Ceiling((double)invoices.Count / pageSize),
               list = response.ToList()
            };
            return ApiResponse<PageResponse<InvoiceForAdminResponse>>.SuccessResponse(pageResponse);
        }

        public async Task<ApiResponse<InvoiceForAdminResponse>> GetInvoiceById(int invoiceId) {

            var invoice = await invoiceRepo.GetInvoicesByInvoicesId(invoiceId);
            if ( invoice == null  ) {
                return ApiResponse<InvoiceForAdminResponse>.FailResponse("Không tìm thấy hóa đơn." + invoiceId.ToString());
            }
            

            var respon = new InvoiceForAdminResponse {
                invoiceId = invoice.InvoiceId,
                totalAmount = invoice.TotalAmount,
                totalQuantity = invoice.TotalQuantity,
                isPayment = invoice.IsPayment,
                invoiceType = invoice.InvoiceType,
                invoiceStatusName = invoice.InvoiceStatus != null ? invoice.InvoiceStatus.InvoiceStatusName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                customerId = invoice.customerId,
                invoiceStatusId = invoice.InvoiceStatusId,
                customerName = invoice.customers != null ? invoice.customers.FullName : "Khách vãng lai",
                create_At = invoice.Create_At.ToString("HH:mm dd/MM/yyyy"),
                tableId = invoice.tableId != null ? invoice.tableId : 0,
                paymentMethodName = invoice.PaymentMethod != null ? invoice.PaymentMethod.PaymentMethodName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                employeeId = invoice.employeeId,
                productReviews = invoice.productReviews != null ? invoice.productReviews.Select(pr => new ProductReviewResponse {
                    productReviewId = pr.ProductReviewId,
                    rating = pr.Rating,
                    comment = pr.Comment,
                    create_At = pr.Create_At,
                    userName = pr.Customers != null ? pr.Customers.FullName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                }).ToList() : new List<ProductReviewResponse>(),
                invoiceItems = invoice.invoiceItems != null ? invoice.invoiceItems.Select(ii => new InvoiceItemResponse {
                    productName = ii.Products != null ? ii.Products.ProductName : "Dữ liệu lỗi. Vui lòng thử lại sao ",
                    quantity = ii.Quantity,
                    price = ii.Price,
                    productImage = ii.Products?.images?.FirstOrDefault()?.ImagesUrl ?? "Img",
                    options = ii.orderItemOptions != null ? ii.orderItemOptions.Select(oio => new InvoiceItemOptionRespon {
                        optionName = oio.OrderItemOptionName,
                        quantity = oio.Quantity,
                        price = oio.Price
                    }).ToList() : new List<InvoiceItemOptionRespon>()
                }).ToList() : new List<InvoiceItemResponse>()
            };
            if (invoice.AddressId != 1) {
                respon.addressDetail = invoice.address != null ?
                       string.Join(", ", new[] {
                           $"{invoice.address.HouseNumber} , Đường: {invoice.address.Street}".Trim(),
                           invoice.address.Hamlet,
                           invoice.address.District,
                           invoice.address.Province
                       }.Where(s => !string.IsNullOrWhiteSpace(s)))

                : "Khách vãng lai";
            }
            else {
                respon.addressDetail = "Tại cửa hàng";
            }
                return ApiResponse<InvoiceForAdminResponse>.SuccessResponse(respon);
        }

        public async Task<ApiResponse<RevenueDayResponse>> GetRevenueByDay(DateTime date) {
            var invoices = await  invoiceRepo.GetDailyRevenueAsync(date.Year,date.Month);
            if ( invoices == null ) {
                return ApiResponse<RevenueDayResponse>.FailResponse("No invoices found for the day.");
            }
            var respon = new RevenueDayResponse {
                year = date.Year,
                month = date.Month,
                dailyRevenue = invoices
            };
            return ApiResponse<RevenueDayResponse>.SuccessResponse(respon);
        }

        public async Task<ApiResponse<RevenueMonth>> GetRevenueByMonth(int year) {
            var invoices = await invoiceRepo.GetMonthlyRevenueAsync(year);
            if ( invoices == null ) { 
                return ApiResponse<RevenueMonth>.FailResponse("No invoices found for the month.");
            }
            var respon = new RevenueMonth {
                year = year,
                monthlyRevenue = invoices
            };
            return ApiResponse<RevenueMonth>.SuccessResponse(respon);
        }

        public async Task<ApiResponse<bool>> UpdatePayMent(int invoiceId) {
            var invoice = await invoiceRepo.GetById(invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Đã xảy ra lỗi trong quá trình cập nhật trạng thái thanh toán.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                
                invoice.IsPayment = true;
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);

            }
            catch ( Exception ex ) { 
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Đã xảy ra lỗi trong quá trình cập nhật trạng thái thanh toán." + ex.Message.ToString());
            }
        }

        public async Task<ApiResponse<bool>> DeleteCartByInvoiceId(int invoiceId) {
            var invoice = await invoiceRepo.GetInvoiceForCart(invoiceId);
            if ( invoice == null || invoice.customerId == null || !invoice.invoiceItems.Any() ) {
                return ApiResponse<bool>.FailResponse("Invoice not found");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                var customerId = invoice.customerId!.Value;
                if ( customerId < 0 ) {
                    return ApiResponse<bool>.FailResponse("Invoice not found2");

                }
                var cart = await cartRepo.GetCart(customerId);
                if ( cart == null ) {
                    return ApiResponse<bool>.FailResponse("Cart not found");
                }
                foreach ( var item in invoice.invoiceItems ) {
                    var cartItem = cart.CartItems.FirstOrDefault(s => s.ProductId == item.ProductId);
                    if ( cartItem != null ) {
                        cart.CartItems.Remove(cartItem);
                    }
                }
                cart.TotalAmount -= cart.CartItems.Sum(item => item.Quantity * item.Price + item.CartItemOptions.Sum(t => t.price * t.quantity));
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch ( Exception ex ) { 
            
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi hệ thống" + ex.Message);
            }
        }

        public async Task<ApiResponse<DashboardSummaryResponse>> GetDashboardSummary() {
            
            var result = await invoiceRepo.GetAllInvoiceByDay(DateTime.Now);
            var totalOrder = result.Count();
            var pendingOrder = result.Where(item => item.InvoiceStatusId == 1).Count();
            var cancelOrder = result.Where(item => item.InvoiceStatusId == 5).Count();
            var comleteOrder = result.Where(item => item.InvoiceStatusId == 4).Count();
            var totalAmount = result.Where(item => item.InvoiceStatusId == 4).Sum(item => item.TotalAmount);
            
            var res = new DashboardSummaryResponse() {
                todayRevenue = totalAmount,
                pendingOrders = pendingOrder,
                cancelledOrders = cancelOrder,
                completedOrders = comleteOrder,
                totalOrdersToday = totalOrder,

            };
            return ApiResponse<DashboardSummaryResponse>.SuccessResponse(res);
        }

        public async Task SendEmailError(int invoiceId, string reason) {
            var invoice = await invoiceRepo.GetByIdForEmail(invoiceId);

            if ( invoice == null || invoice.customers == null) {
                Console.WriteLine("Không tìm thấy hóa đơn. hoặc không có thông tin khách hàng");
                return;
            }
            var toEmail = invoice.customers.Email;
            var subject = $"❌ Đơn hàng #{invoiceId} không thể xử lý";

            var body = $@"
                <div style=""font-family:Arial, sans-serif;padding:20px;border:1px solid #eee;"">
                    <h2 style=""color:#dc3545;"">Đơn hàng gặp sự cố</h2>
                    <p>Xin chào <b>{invoice.customers.FullName}</b>,</p>
                    <p>Rất tiếc, chúng tôi chưa thể xử lý đơn hàng <b>#{invoiceId}</b> của bạn.</p>

                    <p><b>Lý do:</b> {reason}</p>

                    <p>Vui lòng kiểm tra lại hoặc liên hệ hỗ trợ để được giúp đỡ.</p>

                    <hr/>
                    <p style=""color:#888;font-size:12px;"">Đây là email tự động, vui lòng không phản hồi.</p>
                </div>";

            await emailService.SendEmailAsync(toEmail, subject, body);
        }
        public async Task SendEmailSuccess(int invoiceId, string reason) {
            var invoice = await invoiceRepo.GetByIdForEmail(invoiceId);

            if ( invoice == null || invoice.customers == null ) {
                Console.WriteLine("Không tìm thấy hóa đơn. hoặc không có thông tin khách hàng");
                return;
            }

            var toEmail = invoice.customers.Email;
            var subject = $"✅ Đơn hàng #{invoiceId} của bạn đã được xử lý thành công";

            var body = $@"
            <div style=""font-family:Arial, sans-serif;padding:20px;border:1px solid #eee;"">
                <h2 style=""color:#28a745;"">Đơn hàng đã xử lý thành công</h2>
                <p>Xin chào <b>{invoice.customers.FullName}</b>,</p>
                <p>Đơn hàng <b>#{invoiceId}</b> của bạn đã được xử lý thành công.</p>

                <p><b>Lý do / Ghi chú:</b> {reason}</p>

                <hr/>
                <p style=""color:#888;font-size:12px;"">Đây là email tự động, vui lòng không phản hồi.</p>
            </div>";

            await emailService.SendEmailAsync(toEmail, subject, body);
        }

    }
}
