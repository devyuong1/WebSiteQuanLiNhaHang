using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IPurchaseInvoiceServices {
        Task<ApiResponse<bool>> AddPurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        Task<ApiResponse<bool>> UpdatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        Task<ApiResponse<bool>> PaymentPurchaseInvoice(int purchaseInvoiceId);
        Task<ApiResponse<PageResponse<PurchaseInvoiceResponse>>> GetAllPurchaseInvoices(int page = 1);
        Task<ApiResponse<PurchaseInvoiceResponse>> GetPurchaseInvoiceById(int purchaseInvoiceId);
        Task<ApiResponse<purchaseInvoiceDashboard>> GetPurchaseInvoiceDashboard();
    }
}
