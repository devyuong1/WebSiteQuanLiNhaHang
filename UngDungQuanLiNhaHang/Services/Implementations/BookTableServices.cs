using Hangfire;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class BookTableServices(
        BookTableRepo bookTableRepo,
        TransactionRepo transactionRepo
        ) : IBookTableServices {


        public async Task<ApiResponse<bool>> CancelBookingAsync(int customerId, int bookTableId) {
            var booking = await bookTableRepo.GetBookTableByIdAndCustomerId(bookTableId, customerId);
            if ( booking == null ) {
                return ApiResponse<bool>.FailResponse("Không tìm thấy đặt bàn");
            }
            if ( booking.BookTableStatus != null && booking.BookTableStatus.status == "Cancelled" ) {
                return ApiResponse<bool>.FailResponse("Trạng thái đang là hủy");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                booking.bookTableStatusId = 4; // Cancelled
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Hủy đặt bàn thành công");

            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Hủy đặt bàn thất bại" + ex.ToString());
            }
        }

        public async Task CancelBookingAsync(int bookTableId) {
            var booking = await bookTableRepo.GetBookingByIdAsync(bookTableId);
            if ( booking == null ) {
                return;
            }
            if ( booking.BookTableStatus != null && booking.BookTableStatus.status == "Cancelled" ) {
                return;
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                booking.bookTableStatusId = 4; // Cancelled
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                Console.WriteLine($"Booking {bookTableId} bị hủy tự động do không thanh toán.");
                return;

            }
            catch ( Exception ) {
                await transactionRepo.RollbackAsync();
                Console.WriteLine($"Lỗi khi  hủy tự động Booking {bookTableId} do không thanh toán.");
                return;
            }
        }

        public async Task<ApiResponse<BookTableResponse>> CreateBookingAsync(int customerId, BookTableDTO dto) {
            var existingBooking = await bookTableRepo.GetBookTableByDate(dto.bookingDate, dto.tableId);
            // Kiểm tra nếu đã có đặt bàn trong khung giờ này

            if ( existingBooking != null && existingBooking.bookTableStatusId != 4 ) {
                return ApiResponse<BookTableResponse>.FailResponse("Bàn đã được đặt trong khung giờ này");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                var newBooking = new BookTable {
                    customerId = customerId,
                    TableId = dto.tableId,
                    BookingDate = dto.bookingDate,
                    bookTableStatusId = 1, // Pending
                    NumberOfGuests = dto.numberOfGuests,
                    IsDepositPaid = false,
                    DepositAmount = 300000.0,
                    Create_At = DateTime.Now,

                };
                await bookTableRepo.AddAsync(newBooking);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                var response = new BookTableResponse {
                    bookTableId = newBooking.BookTableId,
                    bookingDate = newBooking.BookingDate,
                    depositAmount = newBooking.DepositAmount,
                    isDepositPaid = newBooking.IsDepositPaid,
                    tableId = newBooking.TableId,
                    statusId = newBooking.bookTableStatusId,
                    numberOfPeople = newBooking.NumberOfGuests,
                    statusName = "Chờ xử lý."
                };

                BackgroundJob.Schedule<IBookTableServices>(
                    service => service.CancelBookingAsync(newBooking.BookTableId),
                    TimeSpan.FromMinutes(15)
                );


                return ApiResponse<BookTableResponse>.SuccessResponse(response, "Đặt bàn thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<BookTableResponse>.FailResponse("Đặt bàn thất bại" + ex.ToString());
            }
        }



        public async Task<ApiResponse<PageResponse<BookTableResponse>>> GetAllBookingsAsync(DateTime date, int page = 1) {
            int pageSize = 12;
            var bookings = await bookTableRepo.GetAllBookingsAsync(date);
            if ( bookings == null || bookings.Count == 0 ) {
                return ApiResponse<PageResponse<BookTableResponse>>.FailResponse("Không có đặt bàn nào");
            }
            var responseList = bookings.Select(b => new BookTableResponse {
                bookTableId = b.BookTableId,
                bookingDate = b.BookingDate,
                depositAmount = b.DepositAmount,
                isDepositPaid = b.IsDepositPaid,
                tableId = b.TableId,
                statusId = b.bookTableStatusId,
                numberOfPeople = b.NumberOfGuests,
                statusName = b.BookTableStatus != null ? b.BookTableStatus.status : "Unknown",
                CustomerName = b.Customers != null ? b.Customers.FullName : "Unknown"
            }).ToList();
            int totalItems = responseList.Count;
            var pagedData = responseList
                .Skip(( page - 1 ) * pageSize)
                .Take(pageSize)
                .ToList();
            var pageResponse = new PageResponse<BookTableResponse> {
                totalItems = totalItems,
                pageSize = pageSize,
                page = page,
                list = pagedData
            };
            return ApiResponse<PageResponse<BookTableResponse>>.SuccessResponse(pageResponse, "Lấy danh sách đặt bàn thành công");
        }
        public async Task<ApiResponse<List<BookTableResponse>>> GetBookingsByCustomerAsync(int customerId) {
            var bookings = await bookTableRepo.GetAllBookingsByCustomerIdAsync(customerId);
            if ( bookings == null || bookings.Count == 0 ) {
                return ApiResponse<List<BookTableResponse>>.FailResponse("Không có đặt bàn nào");
            }
            var responseList = bookings.Select(b => new BookTableResponse {
                bookTableId = b.BookTableId,
                bookingDate = b.BookingDate,
                depositAmount = b.DepositAmount,
                isDepositPaid = b.IsDepositPaid,
                tableId = b.TableId,
                statusId = b.bookTableStatusId,
                numberOfPeople = b.NumberOfGuests,
                statusName = b.BookTableStatus != null ? b.BookTableStatus.status : "Unknown"
            }).ToList();
            return ApiResponse<List<BookTableResponse>>.SuccessResponse(responseList, "Lấy danh sách đặt bàn thành công");
        }
        public async Task<ApiResponse<PageResponse<BookTableResponse>>> GetBookingsByStatusIdAsync(DateTime date, int id, int page = 1) {
            int pageSize = 12;
            var bookings = await bookTableRepo.GetBookingsByStatusIdAsync(date, id);
            if ( bookings == null || bookings.Count == 0 ) {
                return ApiResponse<PageResponse<BookTableResponse>>.FailResponse("Không có đặt bàn nào");
            }
            var responseList = bookings.Select(b => new BookTableResponse {
                bookTableId = b.BookTableId,
                bookingDate = b.BookingDate,
                depositAmount = b.DepositAmount,
                isDepositPaid = b.IsDepositPaid,
                tableId = b.TableId,
                statusId = b.bookTableStatusId,
                numberOfPeople = b.NumberOfGuests,
                statusName = b.BookTableStatus != null ? b.BookTableStatus.status : "Unknown",
                CustomerName = b.Customers != null ? b.Customers.FullName : "Unknown"
            }).ToList();
            int totalItems = responseList.Count;
            var pagedData = responseList
                .Skip(( page - 1 ) * pageSize)
                .Take(pageSize)
                .ToList();
            var pageResponse = new PageResponse<BookTableResponse> {
                totalItems = totalItems,
                pageSize = pageSize,
                page = page,
                list = pagedData
            };
            return ApiResponse<PageResponse<BookTableResponse>>.SuccessResponse(pageResponse, "Lấy danh sách đặt bàn theo trạng thái thành công");
        }

        public async Task<ApiResponse<bool>> UpdateBookingStatusAsync(int bookTableId, int statusID) {
            var booking = await bookTableRepo.GetBookingByIdAsync(bookTableId);
            if ( booking == null ) {
                return ApiResponse<bool>.FailResponse("Không tìm thấy đặt bàn");
            }
            if ( booking != null && booking.bookTableStatusId == 4 ) {
                return ApiResponse<bool>.FailResponse("Trạng thái đang là hủy");
            }
            if (  booking.bookTableStatusId >= statusID ) {
                return ApiResponse<bool>.FailResponse("Trạng thái không hợp lệ");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                booking.bookTableStatusId = statusID;

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật trạng thái đặt bàn thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Cập nhật trạng thái đặt bàn thất bại" + ex.ToString());
            }
        }
    }
}
