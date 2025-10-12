using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class SupplierRepo(DataDbConText _context) {
        private readonly DataDbConText _context = _context;
        public async Task<List<Suppliers>> GetAllSuppliers() {
            return await _context.suppliers.Include(s => s.Address).ToListAsync();
        }
        public async Task<Suppliers?> GetSupplierById(int supplierId) {
            return await _context.suppliers
                .Include(s => s.Address)
                .FirstOrDefaultAsync(a => a.SupplierID == supplierId);
        }
        public async Task<Suppliers?> GetByName(string supplierName) {
            return await _context.suppliers.FirstOrDefaultAsync(s => s.SupplierName == supplierName);
        }
        public async Task AddSupplier(Suppliers suppliers) {
            await _context.suppliers.AddAsync(suppliers);
        }
        public void UpdateSupplier(Suppliers suppliers) {
            _context.suppliers.Update(suppliers);
        }
    }
}
