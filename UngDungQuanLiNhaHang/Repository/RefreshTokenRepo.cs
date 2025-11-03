using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class RefreshTokenRepo(DataDbConText _context) {
        public async Task<RefreshTokens?> GetCustomerByRf(string rf) {
            return await _context.refreshTokens
                .Include(s => s.Customers)
                    .ThenInclude( a => a.Role)
                .FirstOrDefaultAsync(s => s.Token == rf);
        }
        public async Task<RefreshTokens?> GetEmployeeByRf(string rf) {
            return await _context.refreshTokens
                .Include(s => s.Employees)
                    .ThenInclude( a => a.Role)
                .FirstOrDefaultAsync(s => s.Token == rf);
        }
    }
}
