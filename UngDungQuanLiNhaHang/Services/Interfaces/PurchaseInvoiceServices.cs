using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface PurchaseInvoiceServices {
        public Task<ApiResponse<bool>> AddPurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        public Task<ApiResponse<bool>> UpdatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO);
        public Task<ApiResponse<bool>> DeletePurchaseInvoice(int purchaseInvoiceId);
        public Task<ApiResponse<List<PurchaseInvoiceDTO>>> GetAllPurchaseInvoices();
        public Task<ApiResponse<PurchaseInvoiceResponse>> GetPurchaseInvoiceById(int purchaseInvoiceId);
    }
}
