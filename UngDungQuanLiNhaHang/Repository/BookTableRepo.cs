using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class BookTableRepo(DataDbConText _context) {
        public async Task<Tables?> IsBookTableExists(int tableId) {
            return await _context.tables.FindAsync(tableId);
        }
        public async Task<BookTable?> GetBookTableByDate(DateTimeOffset bookingTime, int tableId,int customerId) {
            return await _context.bookTables
                .FirstOrDefaultAsync(
                b => b.BookingDate.Hour <= bookingTime.Hour + 4 && b.BookingDate.Hour >= bookingTime.Hour - 4
                && b.BookingDate.Date == bookingTime.Date
                && b.TableId == tableId
                && b.customerId == customerId
                );
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
        public async Task<List<BookTable>> GetBookingsByStatusIdAsync(DateTime? date, int statusId) {
            var query = _context.bookTables
                .Include(b => b.BookTableStatus)
                .Include(b => b.Customers)
                .Where(b => b.bookTableStatusId == statusId);

                    if ( date.HasValue ) {
                        var start = date.Value.Date;
                        var end = start.AddDays(1);

                        query = query.Where(b => b.BookingDate >= start && b.BookingDate < end);
                    }

                    return await query
                        .OrderByDescending(b => b.BookingDate)
                        .ToListAsync();
        }
        public async Task<BookTable?> GetBookingByIdAsync(int bookTableId) {
            return await _context.bookTables
                .FirstOrDefaultAsync(b => b.BookTableId == bookTableId);
        }
        public async Task<List<Tables>?> GetByNumberOfGuests(int quantity) {
            return await _context.tables.Where(s => s.Capacity >= quantity).ToListAsync();
        }
        public async Task<List<BookTable>> GetBookTableByDate(DateTimeOffset bookingTime) {
            return await _context.bookTables
                .Where(
                b => b.BookingDate.Hour <= bookingTime.Hour + 4 && b.BookingDate.Hour >= bookingTime.Hour - 4
                && b.BookingDate.Date == bookingTime.Date
                ).ToListAsync();
        }
        public async Task<List<Tables>> GetAllTable() {
            return await _context.tables.
                Include(i => i.Invoices)
                .ToListAsync();
        }
        public async Task<Tables?> GetTableById(int tableId) {
            return await _context.tables.FirstOrDefaultAsync(s => s.TableId == tableId);
        }
        public void  UpdateTable(Tables tables) {
            _context.tables.Update(tables);
        }
    }
}
