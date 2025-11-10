using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IBookTableServices {

        // customer 
        Task<ApiResponse<string>> CreateBookingAsync(int customerID ,BookTableDTO dto,HttpContext context);
        Task<ApiResponse<bool>> CancelBookingAsync(int customerId, int bookTableId);
        Task CancelBookingAsync(int bookTableId);
        Task<ApiResponse<List<BookTableResponse>>> GetBookingsByCustomerAsync(int customerId);
        Task<ApiResponse<List<TableResponse>>> GetTablesByDate(DateTimeOffset date, int numberOfGuests);

        // Staff
        Task<ApiResponse<PageResponse<BookTableResponse>>> GetAllBookingsAsync(DateTime time,int page = 1);
        Task<ApiResponse<PageResponse<BookTableResponse>>> GetBookingsByStatusIdAsync(DateTime? time ,int id,int page = 1 );
        Task<ApiResponse<bool>> UpdateBookingStatusAsync(int bookTableId, int statusID);
        Task<ApiResponse<bool>> UpdateBookingPayment(int bookTableId);
        Task<ApiResponse<List<int>>> GetTableId();
        Task<ApiResponse<List<TableResponse>>> GetAllTablesByDate();

    }
}
