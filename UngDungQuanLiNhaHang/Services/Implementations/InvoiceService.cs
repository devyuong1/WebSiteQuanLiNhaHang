using Hangfire;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class InvoiceService(InvoiceRepo invoiceRepo,
        TransactionRepo transactionRepo,
        ProductRepo productRepo,
        ProductOptionRepo productOptionRepo,
        CartRepo cartRepo,
        EmployeeRepo employeeRepo,
        BookTableRepo bookTableRepo
        ) : IInvoiceServices {
        public async Task<ApiResponse<bool>> AddInvoiceItem(int employeeId, InvoiceItemDTO invoiceItemDTO) {
            bool isEmployeeExists = await employeeRepo.IsEmployeeExists(employeeId);
            if ( !isEmployeeExists ) {
                return ApiResponse<bool>.FailResponse("Nhân viên không tồn tại.");
            }
            var invoice = await invoiceRepo.GetByInvoiceIdForAddItem(invoiceItemDTO.invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if ( invoice.InvoiceStatusId != 2 ) {
                return ApiResponse<bool>.FailResponse("Chỉ có thể thêm sản phẩm vào hóa đơn đã xác nhận.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                var product = await productRepo.GetProductById(invoiceItemDTO.productId);
                if ( product == null )
                    return ApiResponse<bool>.FailResponse("Dữ liệu product  không hợp lệ.");
                var invoiceItem = invoice.invoiceItems.FirstOrDefault(s => s.ProductId == invoiceItemDTO.productId);
                if ( invoiceItem == null ) {
                    InvoiceItems items = new InvoiceItems() {
                        Quantity = invoiceItemDTO.quantity,
                        Price = invoiceItemDTO.price,
                        ProductId = invoiceItemDTO.productId,
                        InvoiceId = invoice.InvoiceId,
                    };
                    product.Quantity -= items.Quantity;
                    if ( invoiceItemDTO.productOptions.Any() ) {
                        foreach ( var i in invoiceItemDTO.productOptions ) {
                            var productOption = await productOptionRepo.GetById(i.Id);
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
                    invoice.TotalAmount += invoiceItemDTO.quantity * invoiceItemDTO.price;
                    invoice.TotalQuantity += 1;
                }
                else {

                    if ( invoiceItemDTO.quantity > 0 ) {
                        invoiceItem.Quantity += invoiceItemDTO.quantity;
                        product.Quantity -= invoiceItemDTO.quantity;
                        invoice.TotalAmount += invoiceItemDTO.price * invoiceItemDTO.quantity;
                    }
                    if ( invoiceItemDTO.productOptions.Any() ) {
                        foreach ( var i in invoiceItemDTO.productOptions ) {
                            var productOption = await productOptionRepo.GetById(i.Id);
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
                            invoice.TotalAmount += i.quantity * productOption.Price;
                        }
                    }

                }
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception e ) {
                await transactionRepo.RollbackAsync();
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
                return;
            }
        }

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
            var carts = await cartRepo.GetCart(customerId);

            if ( carts == null || carts.CartItems.Count == 0 ) {
                return ApiResponse<bool>.FailResponse("Customer not found");
            }


            // tao hoa don
            Invoices invoices = new Invoices();
            invoices.customerId = customerId;
            invoices.AddressId = invoiceDTO.addressId;
            invoices.PaymentMethodId = invoiceDTO.paymentMethodId;

            invoices.TotalQuantity = invoiceDTO.totalQuantity;
            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum(s => s.quantity * s.price);
            invoices.IsPayment = invoiceDTO.isPayment;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = false;
            invoices.Create_At = DateTime.Now;
            try {
                await transactionRepo.BeginTransactionAsync();
                // xoa san pham trong gio hang va cap nhat so luong san pham
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
                    var cartitem = carts.CartItems.Where(s => s.ProductId == item.productId).FirstOrDefault();
                    if ( cartitem == null ) {
                        return ApiResponse<bool>.FailResponse("Sản phẩm không tồn tại trong giỏ hàng");
                    }
                    // xoa san pham ra khoi gio hang
                    carts.CartItems.Remove(cartitem);

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
                    if ( item.productOptions != null && item.productOptions.Any() ) {
                        foreach ( var i in item.productOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.Id);
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

                var response = new InvoideForPaymentResponse {
                    invoiceId = invoices.InvoiceId,
                    totalAmount = invoices.TotalAmount,
                    customerName = carts.Customers.FullName,
                    isPayMent = false,
                    paymentMethodId = invoices.PaymentMethodId,
                    invoiceStatusId = invoices.InvoiceStatusId,
                    invoiceType = false,
                    create_At = invoices.Create_At
                };
                // sap xep 15 phut neu khach hang khong thanh toan thi huy hoa don
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Đặt hàng thành công.");


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
            }
        }

        // tao hoa don offline cho khach hang dat ban
        public async Task<ApiResponse<bool>> CreateInvoiceForBookTable(int employeeId, InvoiceOffLineDTO invoiceDTO) {
            var bookTable = await bookTableRepo.GetBookTableByDate(DateTime.Now, invoiceDTO.tableId);
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
            Invoices invoices = new Invoices();
            invoices.TotalQuantity = invoiceDTO.invoiceItems.Count;
            // tru di so tien coc DepositAmount
            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum(s => s.quantity * s.price) - bookTable.DepositAmount;
            invoices.IsPayment = false;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = true;
            invoices.Create_At = DateTime.Now;
            invoices.employeeId = employeeId;
            invoices.tableId = invoiceDTO.tableId;
            invoices.customerId = bookTable.customerId;
            try {
                await transactionRepo.BeginTransactionAsync();
                // xoa san pham trong gio hang va cap nhat so luong san pham
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
                    if ( item.productOptions != null && item.productOptions.Count() > 0 ) {
                        foreach ( var i in item.productOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.Id);
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
                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
            }
        }

        // tao hoa don offline cho khach hang tai quan
        public async Task<ApiResponse<bool>> CreateInvoiceForOffLine(int employeeId, InvoiceOffLineDTO invoiceDTO) {
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
            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum(s => s.quantity * s.price);
            invoices.IsPayment = false;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = true;
            invoices.Create_At = DateTime.Now;
            invoices.employeeId = employeeId;
            try {
                await transactionRepo.BeginTransactionAsync();
                // xoa san pham trong gio hang va cap nhat so luong san pham
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
                    if ( item.productOptions != null && item.productOptions.Any() ) {
                        foreach ( var i in item.productOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.Id);
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
                return ApiResponse<bool>.SuccessResponse(true);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
            }
        }

        // Hoa don online cho khach hang kem voi thanh toan online
        public async Task<ApiResponse<InvoideForPaymentResponse>> CreateInvoiceForOnline(int customerId, InvoiceDTO invoiceDTO) {
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

            invoices.TotalQuantity = invoiceDTO.totalQuantity;
            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum(s => s.quantity * s.price);
            invoices.IsPayment = invoiceDTO.isPayment;
            invoices.InvoiceStatusId = 1;
            invoices.InvoiceType = false;
            invoices.Create_At = DateTime.Now;
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
                    // xoa san pham ra khoi gio hang
                    carts.CartItems.Remove(cartitem);

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
                    if ( item.productOptions != null && item.productOptions.Any() ) {
                        foreach ( var i in item.productOptions ) {
                            // kiem tra xem productOption co ton tai hay khong
                            var productOption = await productOptionRepo.GetById(i.Id);
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

                var response = new InvoideForPaymentResponse {
                    invoiceId = invoices.InvoiceId,
                    totalAmount = invoices.TotalAmount,
                    customerName = carts.Customers.FullName,
                    isPayMent = false,
                    paymentMethodId = invoices.PaymentMethodId,
                    invoiceStatusId = invoices.InvoiceStatusId,
                    invoiceType = false,
                    create_At = invoices.Create_At
                };
                // sap xep 15 phut neu khach hang khong thanh toan thi huy hoa don
                BackgroundJob.Schedule<IInvoiceServices>(x => x.CancellInvoiceOnlineForStaff(invoices.InvoiceId), TimeSpan.FromMinutes(15));
                await transactionRepo.CommitAsync();
                return ApiResponse<InvoideForPaymentResponse>.SuccessResponse(response);


            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<InvoideForPaymentResponse>.FailResponse("Lỗi khi thêm hóa đơn." + ex.Message);
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
                totalQuantity = i.TotalQuantity,
                totalAmount = i.TotalAmount,
                isPayMent = i.IsPayment,
                invoiceType = i.InvoiceType,
                create_At = i.Create_At,
                paymentMethodName = i.PaymentMethod != null ? i.PaymentMethod.PaymentMethodName : "Dữ liệu lỗi. Vui lòng thử lại sao ",
                invoiceStatusId = i.InvoiceStatusId,
                invoiceItems = i.invoiceItems.Select(ii => new InvoiceItemResponse {
                    productName = ii.Products != null ? ii.Products.ProductName : "Dữ liệu lỗi. Vui lòng thử lại sao ",
                    quantity = ii.Quantity,
                    price = ii.Price,
                    productImage = ii.Products != null ? ( ii.Products.images != null ? ii.Products.images.FirstOrDefault().ImagesUrl : "Img" ) : "Img",
                    productOptions = ii.orderItemOptions != null ? ii.orderItemOptions.Select(oio => new ProductOptionResponse {
                        optionName = oio.OrderItemOptionName,
                        quantity = oio.Quantity,
                        price = oio.Price
                    }).ToList() : new List<ProductOptionResponse>()
                }).ToList()
            }).ToList();
            return ApiResponse<List<InvoiceForCustomerResponse>>.SuccessResponse(response);
        }

        public async Task<ApiResponse<bool>> UpdateActiveInvoice(int invoiceId, int statusId) {
            var invoice = await invoiceRepo.GetById(invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Không có hóa đơn");
            }
            if ( statusId <= 0 || statusId > 4 || statusId <= invoice.InvoiceStatusId ) {
                return ApiResponse<bool>.FailResponse("Trạng thái không hợp lệ");
            }
            invoice.InvoiceStatusId = statusId;
            try {
                await transactionRepo.BeginTransactionAsync();

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
                return ApiResponse<PageResponse<InvoiceForAdminResponse>>.FailResponse("Không có hóa đơn nào trong hôm nay.");
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
                invoiceStatusName = i.InvoiceStatus != null ? i.InvoiceStatus.InvoiceStatusName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                create_At = i.Create_At,
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
                return ApiResponse<InvoiceForAdminResponse>.FailResponse("Không tìm thấy hóa đơn.");
            }
            var respon = new InvoiceForAdminResponse {
                invoiceId = invoice.InvoiceId,
                totalAmount = invoice.TotalAmount,
                totalQuantity = invoice.TotalQuantity,
                isPayment = invoice.IsPayment,
                invoiceType = invoice.InvoiceType,
                invoiceStatusName = invoice.InvoiceStatus != null ? invoice.InvoiceStatus.InvoiceStatusName : "Dữ liệu lỗi. Vui lòng thử lại sau.",
                customerId = invoice.customerId,
                customerName = invoice.customers != null ? invoice.customers.FullName : "Khách vãng lai",
                create_At = invoice.Create_At,
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
                addressDetail = invoice.address != null ?
                       string.Join(", ", new[] {
                           $"{invoice.address.HouseNumber} {invoice.address.Street}".Trim(),
                           invoice.address.Hamlet,
                           invoice.address.District,
                           invoice.address.Province
                       }.Where(s => !string.IsNullOrWhiteSpace(s)))

                : "Khách vãng lai",
                invoiceItems = invoice.invoiceItems != null ? invoice.invoiceItems.Select(ii => new InvoiceItemResponse {
                    productName = ii.Products != null ? ii.Products.ProductName : "Dữ liệu lỗi. Vui lòng thử lại sao ",
                    quantity = ii.Quantity,
                    price = ii.Price,
                    productImage = ii.Products?.images?.FirstOrDefault()?.ImagesUrl ?? "Img",
                    productOptions = ii.orderItemOptions != null ? ii.orderItemOptions.Select(oio => new ProductOptionResponse {
                        optionName = oio.OrderItemOptionName,
                        quantity = oio.Quantity,
                        price = oio.Price
                    }).ToList() : new List<ProductOptionResponse>()
                }).ToList() : new List<InvoiceItemResponse>()
            };
        
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
    }
}
