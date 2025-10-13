using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class BookTableRepo(DataDbConText _context) {
        public async Task<BookTable?> GetBookTableByDate(DateTime bookingTime, int tableId) {
            return await _context.bookTables
                .FirstOrDefaultAsync(
                b =>  b.BookingDate.Hour == bookingTime.Hour
                && b.BookingDate.Date == bookingTime.Date
                && b.TableId == tableId);
            
        }
    }
}
