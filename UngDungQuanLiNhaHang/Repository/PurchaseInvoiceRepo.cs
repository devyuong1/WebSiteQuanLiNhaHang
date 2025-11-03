using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UngDungQuanLiNhaHang.Repository {
    public class PurchaseInvoiceRepo(DataDbConText _context) {
        private readonly DataDbConText _context = _context;
        public async  Task<IEnumerable<PurchaseInvoice>> GetAllPurchaseInvoices() {
            return await _context.purchaseInvoice
                .Include(s => s.Suppliers)
                .Include(s => s.Employees)
                .OrderByDescending(i => i.Create_At)
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
        public async Task<List<PurchaseInvoice>> GetAllByDay(DateTime time) {
            var start = time.Date;
            var end = start.AddDays(1);
            return await _context.purchaseInvoice.Where(item => item.Create_At.Date >= start && item.Create_At < end && item.Create_At.Year == time.Year).ToListAsync();
        }
    }
}
