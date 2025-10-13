using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IInvoiceServices {
        public Task<ApiResponse<InvoideForPaymentResponse>> CreateInvoiceForOnline(int customerId, InvoiceDTO InvoiceDTO);
        public Task<ApiResponse<List<InvoiceForCustomerResponse>>> GetInvoicesByCustomerId(int customerId);
        public Task<ApiResponse<bool>> UpdateActiveInvoice(int invoiceId, int statusId );

        public Task<ApiResponse<bool>> CancellInvoiceForCustomer(int customerId, int invoiceId);
        public Task<ApiResponse<bool>> CancellInvoiceOnlineForStaff(int employeeId, int invoiceId);
        public Task<ApiResponse<bool>> CancellInvoiceOfflineForStaff(int employeeId, int invoiceId);
        public Task<ApiResponse<bool>> CreateInvoiceForOffLine(int employeeId, InvoiceOffLineDTO invoice);
        public Task<ApiResponse<bool>> CreateInvoiceForBookTable(int employeeId, InvoiceOffLineDTO invoice);
        public Task<ApiResponse<bool>> AddInvoiceItem(int employeeId, InvoiceItemDTO invoiceItemDTO);

    }
}
