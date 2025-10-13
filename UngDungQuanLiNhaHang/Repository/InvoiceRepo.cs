using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class InvoiceRepo(DataDbConText _context) {
        public async Task<Invoices?> GetById(int invoiceId) {
            return await _context.invoices.FindAsync(invoiceId);
        }
        public async Task<Invoices?> GetByCustomerIdAndInvoiceIdForCancell(int customerId, int invoiceId) {
            return await _context.invoices
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.orderItemOptions)  
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId && i.customerId == customerId);
        }
        public async Task<Invoices?> GetByInvoiceIdForCancell( int invoiceId) {
            return await _context.invoices
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.orderItemOptions)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId );
        }
        public async Task<Invoices?> GetByInvoiceIdForAddItem(int invoiceId) {
            return await _context.invoices
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.orderItemOptions)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }
        public async Task AddInvoice(Invoices invoice) {
            await _context.invoices.AddAsync(invoice);
        }
        public void UpdateInvoice(Invoices invoice) {
            _context.invoices.Update(invoice);
        }
        public async Task<List<Invoices>> GetInvoicesByCustomerId(int customerId) {
            return await _context.invoices
                .Where(i => i.customerId == customerId)
                .Include(i => i.InvoiceStatus)
                .Include(i => i.PaymentMethod)
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.Products)
                        .ThenInclude(ii => ii.images)
                 .Include(i => i.invoiceItems)
                       .ThenInclude(pp => pp.orderItemOptions)          
                .ToListAsync();
        }
    }
}
