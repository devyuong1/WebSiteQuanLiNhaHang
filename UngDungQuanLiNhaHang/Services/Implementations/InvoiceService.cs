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
        CartRepo cartRepo
        ) : IInvoiceServices {
        public async Task<ApiResponse<int>> CreateInvoiceForOnline(InvoiceDTO invoiceDTO) {
            // kiem tra du lieu
            if (invoiceDTO == null) {
                return ApiResponse<int>.FailResponse("Invalid invoice data.");
            }
            foreach (var item in invoiceDTO.invoiceItems) {
                bool product = await productRepo.IsProductExists(item.productId);
                if (item == null || item.quantity <= 0 || item.price <= 0 || product == false)  {
                    return ApiResponse<int>.FailResponse("Invalid item data.");
                }
            }
            // kiem tra cart 
            var carts = await cartRepo.GetCart(invoiceDTO.customerId);

            if ( carts == null || carts.CartItems.Count == 0 ) {
                return ApiResponse<int>.FailResponse("Customer not found");
            }
            // tao hoa don
            Invoices invoices = new Invoices();
            invoices.customerId = invoiceDTO.customerId;
            invoices.AddressId = invoiceDTO.addressId;
            invoices.PaymentMethodId = invoiceDTO.paymentMethodId;

            invoices.TotalQuantity = invoiceDTO.totalQuantity;
            invoices.TotalAmount = invoiceDTO.invoiceItems.Sum( s => s.quantity * s.price);
            invoices.IsPayment = invoiceDTO.isPayment;
            invoices.InvoiceStatusId = invoiceDTO.invoiceStatusId;
            invoices.InvoiceType = false;
            invoices.Create_At = DateTime.Now;
            try {
                await transactionRepo.BeginTransactionAsync();
                // xoa san pham trong gio hang
                foreach ( var item in invoiceDTO.invoiceItems ) {
                    // kiem tra san pham co ton tai trong gio hang hay khong
                    var cartitem = carts.CartItems.Where(s => s.ProductId == item.productId).FirstOrDefault();
                    if (cartitem == null) {
                        return ApiResponse<int>.FailResponse("Invalid item data.");
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
                                return ApiResponse<int>.FailResponse("ProductOption không hợp lệ.");
                            // them cartItemOption
                            OrderItemOption invoiceItemOptions = new OrderItemOption() {
                                OrderItemOptionName = productOption.OptionName,
                                Quantity = i.quantity,
                                Price = productOption.Price,
                                InvoiceItem = items
                            };
                            invoices.TotalAmount += i.quantity * productOption.Price;

                            items.orderItemOptions.Add(invoiceItemOptions);

                        }
                    }
                    // them cartitem vao cart
                    invoices.invoiceItems.Add(items);
                }
                await invoiceRepo.AddInvoice(invoices);
                await transactionRepo.CompleteAsync();

                await transactionRepo.CommitAsync();
                return ApiResponse<int>.SuccessResponse(invoices.InvoiceId);
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<int>.FailResponse("Lỗi khi thêm hóa đơn."+ex.Message);
            }
        }

        public Task<ApiResponse<InvoiceResponse>> GetInvoiceDetailById(int customerId, int invoiceId) {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<InvoiceResponse>>> GetInvoicesByCustomerId(int customerId) {
            throw new NotImplementedException();
        }
    }
}
