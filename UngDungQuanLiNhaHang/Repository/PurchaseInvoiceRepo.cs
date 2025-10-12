using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class PurchaseInvoiceRepo(DataDbConText _context) {
        private readonly DataDbConText _context = _context;
        public async  Task<IEnumerable<PurchaseInvoice>> GetAllPurchaseInvoices() {
            return await _context.purchaseInvoice
                .Include(s => s.Suppliers)
                .Include(s => s.Employees)
                .ToListAsync();
        }
        public async Task<PurchaseInvoice?> GetPurchaseInvoiceById(int purchaseInvoiceId) {
            return await _context.purchaseInvoice
                .Include(s => s.purchaseInvoiceItems)
                    .ThenInclude(a => a.Ingredient)
                .Include(s => s.Suppliers)
                .Include(s => s.Employees)
                .FirstOrDefaultAsync(pi => pi.PurchaseInvoiceId == purchaseInvoiceId);
        }
        public async Task AddPurcgaseInvoice(PurchaseInvoice purchaseInvoice) {
            await _context.purchaseInvoice.AddAsync(purchaseInvoice);
            
        }
        public void UpdatePurchaseInvoice(PurchaseInvoice purchaseInvoice) {
            _context.purchaseInvoice.Update(purchaseInvoice);
        }
    }
}
