using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IInvoiceServices {
        public Task<ApiResponse<bool>> CreateInvoice(int customerId, InvoiceDTO InvoiceDTO);
        public Task<ApiResponse<List<InvoiceResponse>>> GetInvoicesByCustomerId(int customerId);
        public Task<ApiResponse<InvoiceResponse>> GetInvoiceDetailById(int customerId, int invoiceId);
    }
}
