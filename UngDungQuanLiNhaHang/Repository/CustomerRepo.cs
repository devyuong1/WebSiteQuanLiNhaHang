using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class CustomerRepo(DataDbConText _context) {
        public async Task<bool> IsEmailExist(string email) {
            return await _context.customers.AnyAsync(c => c.Email == email);
        }
        public async Task<bool> IsPhoneExist(string phone) {
            return await _context.customers.AnyAsync(c => c.Phone == phone);
        }
        public async Task AddCustomer(Models.Customers customer) {
            await _context.customers.AddAsync(customer);

        }
        public async Task<Customers?> GetCustomerByEmail(string email) {
            return await _context.customers.FirstOrDefaultAsync(c => c.Email == email);
        }
        public async Task<Customers?> GetCustomerById(int customerId) {
            return await _context.customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public void  UpdateCustomer(Customers customer) {
              _context.customers.Update(customer);
        }
    }
}
