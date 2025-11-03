using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IOrderProcessingService {
        Task<ApiResponse<bool>> CreateInvoiceAndUpdateIngredient(int customerId, InvoiceDTO invoiceDTO);
        Task<ApiResponse<InvoideForPaymentResponse>> CreateInvoiceForOnlineAndUpdateIngredient(int customerId, InvoiceDTO invoiceDTO, HttpContext httpContext);
    }
}
