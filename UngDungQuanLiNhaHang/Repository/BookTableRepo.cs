using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class BookTableRepo(DataDbConText _context) {
        public async Task<BookTable?> GetBookTableByDate(DateTime bookingTime, int tableId) {
            return await _context.bookTables
                .FirstOrDefaultAsync(
                b => b.BookingDate.Hour <= bookingTime.Hour + 4 && b.BookingDate.Hour >= bookingTime.Hour - 4
                && b.BookingDate.Date == bookingTime.Date
                && b.TableId == tableId);
        }
        public async Task<BookTable?> GetBookTableByIdAndCustomerId(int bookTableId, int customerId) {
            return await _context.bookTables
                .Include(b => b.BookTableStatus)
                .FirstOrDefaultAsync(b => b.BookTableId == bookTableId && b.customerId == customerId);
        }
        public async Task AddAsync(BookTable bookTable) {
            await _context.bookTables.AddAsync(bookTable);
        }
        public async Task<List<BookTable>> GetAllBookingsByCustomerIdAsync(int customerId) {
            return await _context.bookTables
                .Include(b => b.BookTableStatus)
                .Where(b => b.customerId == customerId)
                .ToListAsync();
        }
        public async Task<BookTable?> GetBookingDetailAsync(int bookTableId) {
            return await _context.bookTables
                .Include(b => b.BookTableStatus)
                .Include(b => b.Customers)
                .FirstOrDefaultAsync(b => b.BookTableId == bookTableId);
        }
        public async Task<List<BookTable>> GetAllBookingsAsync(DateTime date) {
            return await _context.bookTables
                .Include(b => b.BookTableStatus)
                .Include(b => b.Customers)
                .Where(b => b.BookingDate.Date == date)
                .ToListAsync();
        }
        public async Task<List<BookTable>> GetBookingsByStatusIdAsync(DateTime date, int statusId) {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);

            return await _context.bookTables
                .Include(b => b.BookTableStatus)
                .Include(b => b.Customers)
                .Where(b => b.BookingDate >= startDate && b.BookingDate < endDate
                            && b.bookTableStatusId == statusId)
                .OrderByDescending(b => b.BookingDate) // 👈 sắp xếp theo ngày đặt bàn
                .ToListAsync();
        }
        public async Task<BookTable?> GetBookingByIdAsync(int bookTableId) {
            return await _context.bookTables
                .FirstOrDefaultAsync(b => b.BookTableId == bookTableId);
        }
        public async Task<List<Tables>?> GetByNumberOfGuests(int quantity) {
            return await _context.tables.Where( s => s.Capacity >= quantity).ToListAsync();
        }
        public async Task<List<BookTable>> GetBookTableByDate(DateTime bookingTime) {
            return await _context.bookTables
                .Where(
                b => b.BookingDate.Hour <= bookingTime.Hour + 4 && b.BookingDate.Hour >= bookingTime.Hour - 4
                && b.BookingDate.Date == bookingTime.Date
                ).ToListAsync();
        }
    }
}
