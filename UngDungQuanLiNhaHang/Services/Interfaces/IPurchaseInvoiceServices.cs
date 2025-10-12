using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IPurchaseInvoiceServices {
        public Task<ApiResponse<bool>> AddPurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        public Task<ApiResponse<bool>> UpdatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        public Task<ApiResponse<bool>> PaymentPurchaseInvoice(int purchaseInvoiceId);
        public Task<ApiResponse<PageResponse<PurchaseInvoiceResponse>>> GetAllPurchaseInvoices(int page = 1);
        public Task<ApiResponse<PurchaseInvoiceResponse>> GetPurchaseInvoiceById(int purchaseInvoiceId);
    }
}
