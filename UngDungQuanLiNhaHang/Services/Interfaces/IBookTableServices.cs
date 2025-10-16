using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IBookTableServices {

        // customer 
        Task<ApiResponse<BookTableResponse>> CreateBookingAsync(int customerID ,BookTableDTO dto);
        Task<ApiResponse<bool>> CancelBookingAsync(int customerId, int bookTableId);
        Task CancelBookingAsync(int bookTableId);
        Task<ApiResponse<List<BookTableResponse>>> GetBookingsByCustomerAsync(int customerId);
        

        // Staff
        Task<ApiResponse<PageResponse<BookTableResponse>>> GetAllBookingsAsync(DateTime time,int page = 1);
        Task<ApiResponse<PageResponse<BookTableResponse>>> GetBookingsByStatusIdAsync(DateTime time ,int id,int page = 1 );
        Task<ApiResponse<bool>> UpdateBookingStatusAsync(int bookTableId, int statusID);
        
       
    }
}
