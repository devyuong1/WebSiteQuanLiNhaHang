using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class InvoiceRepo(DataDbConText _context) {
        public async Task<Invoices?> GetById(int invoiceId) {
            return await _context.invoices.FindAsync(invoiceId);
        }
        public async Task AddInvoice(Invoices invoice) {
            await _context.invoices.AddAsync(invoice);
        }
        public void UpdateInvoice(Invoices invoice) {
            _context.invoices.Update(invoice);
        }
    }
}
