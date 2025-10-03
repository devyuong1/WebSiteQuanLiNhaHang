using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class EmployeeRepo(DataDbConText _context) {
        public async Task<IEnumerable<Employees>> GetAllEmployees() {
            return await _context.employees.Include(e => e.roles).Include(e => e.address).ToListAsync();
        }
        public async Task<Employees?> GetEmployeeById(int employeeId) {
            return await _context.employees.FindAsync(employeeId);
        }
        public async Task AddEmployee(Employees employee) {
            await _context.employees.AddAsync(employee);
        }
        public void UpdateEmployee(Employees employee) {
            _context.employees.Update(employee);
        }
        public async Task<Employees?> GetEmployeeByEmail(string email) {
            return await _context.employees.FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<Employees?> GetEmployeeByPhone(string phone) {
            return await _context.employees.FirstOrDefaultAsync(e => e.Phone == phone);
        }
    }
}
