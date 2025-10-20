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
        public async Task AddCustomer(Customers customer) {
            await _context.customers.AddAsync(customer);

        }
        
        public async Task<Customers?> GetCustomerByEmail(string email) {
            return await _context.customers
                .Include(c => c.Role)
                .Include(c => c.refreshTokens)
                .FirstOrDefaultAsync(c => c.Email == email);
        }
        public async Task<Customers?> GetCustomerById(int customerId) {
            return await _context.customers
                .Include(c => c.refreshTokens)
                .Include(c => c.Role)
                .Include(c => c.AddressCustomers)
                    .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public async Task<Customers?> GetCustomerForAddress(int customerId) {
            return await _context.customers
                .Include(c => c.AddressCustomers)
                    .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        

        public async Task<Customers?> GetCustomerByPhonel(string phone) {
            return await _context.customers
               
                .FirstOrDefaultAsync(c => c.Phone == phone);
        }
        public void  UpdateCustomer(Customers customer) {
              _context.customers.Update(customer);
        }

        public async Task<AddressCustomer?> GetAddressById(int customerid,int addressId) {
            return await _context.addressCustomers.Include(s => s.Address).FirstOrDefaultAsync(s => s.CustomerId == customerid && s.AddressId == addressId);
        }
    }
}
