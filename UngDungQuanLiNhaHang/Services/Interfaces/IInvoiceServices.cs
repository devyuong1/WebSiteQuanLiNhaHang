using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IInvoiceServices {
        // khach hàng tạo hóa đơn online để thanh toán
        Task<ApiResponse<InvoideForPaymentResponse>> CreateInvoiceForOnline(int customerId, InvoiceDTO InvoiceDTO, HttpContext httpContext);
        Task<ApiResponse<bool>> CreateInvoiceCustomer(int customerId, InvoiceDTO InvoiceDTO);

        // trả về danh sách hóa đơn của người dùng 
        Task<ApiResponse<List<InvoiceForCustomerResponse>>> GetInvoicesByCustomerId(int customerId);
        Task<ApiResponse<bool>> UpdateActiveInvoice(int invoiceId, int statusId , int employeeId);
        // người dung hủy hóa đơn của mình
        Task<ApiResponse<bool>> CancellInvoiceForCustomer(int customerId, int invoiceId);
        
        // nhân viên hủy hóa đơn tại chỗ cho khách hàng
        Task<ApiResponse<bool>> CancellInvoiceOfflineForStaff(int employeeId, int invoiceId);
        // nhân viên tạo hóa đơn tại chỗ cho khách hàng
        Task<ApiResponse<bool>> CreateInvoiceForOffLine(int employeeId, InvoiceOffLineDTO invoice);
        // nhân viên tạo hóa đơn  cho khách hàng đã đặt bàn 
        Task<ApiResponse<bool>> CreateInvoiceForBookTable(int employeeId, InvoiceOffLineDTO invoice);
        // nhân viên thêm món vào hóa đơn tại chỗ hoặc thêm những phần gọi thêm cho khách hàng đã đặt bàn
        Task<ApiResponse<bool>> AddInvoiceItem(int employeeId, InvoiceItemDTO invoiceItemDTO);
        // hủy hóa đơn online  cho khách hàng khi không đủ điều kiện thanh toán online 
        Task CancellInvoiceOnlineForStaff(int invoiceId);

        // for admin
        Task<ApiResponse<PageResponse<InvoiceForAdminResponse>>> GetAllInvoicesByDayAndStatusId(DateTime Date,int page = 1, int status = 1 );
        Task<ApiResponse<InvoiceForAdminResponse>> GetInvoiceById(int invoiceId);
        Task<ApiResponse<RevenueDayResponse>> GetRevenueByDay(DateTime date);
        Task<ApiResponse<RevenueMonth>> GetRevenueByMonth( int year);
        Task<ApiResponse<DashboardSummaryResponse>> GetDashboardSummary();


        // he thong
        Task<ApiResponse<bool>> UpdatePayMent(int invoiceId);
        Task<ApiResponse<bool>> DeleteCartByInvoiceId(int invoiceId);
        
    }
}
