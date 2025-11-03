using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class InvoiceRepo(DataDbConText _context) {
        public async Task<Invoices?> GetById(int invoiceId) {
            return await _context.invoices.FindAsync(invoiceId);
        }
        public async Task<Invoices?> GetByCustomerIdAndInvoiceId(int customerId, int invoiceId) {
            return await _context.invoices
                .Include(i => i.invoiceItems)
                    
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId && i.customerId == customerId);
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
        public async Task<Invoices?> GetInvoicesByInvoicesId(int InvoicesId) {
            return await _context.invoices
                .Include(i => i.InvoiceStatus)
                .Include(i => i.customers)
                .Include(i => i.address)
                .Include(i => i.PaymentMethod)
                .Include(i => i.invoiceItems)
                    
                    .ThenInclude(ii => ii.Products)
                        .ThenInclude(ii => ii.images)
                 .Include(i => i.invoiceItems)
                       .ThenInclude(pp => pp.orderItemOptions)
                 .FirstOrDefaultAsync(s => s.InvoiceId == InvoicesId);
        }
        public async Task<Invoices?> GetInvoicesByInvoicesIdForUpdateIngredient(int InvoicesId) {
            return await _context.invoices
                .AsNoTracking()
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.Products)     
                 .Include(i => i.invoiceItems)
                       .ThenInclude(pp => pp.orderItemOptions)
                 .FirstOrDefaultAsync(s => s.InvoiceId == InvoicesId);
        }
        public async Task<List<Invoices>> GetAllInvoicesByDateAndStatusId(DateTime date, int statusId) {
            return await _context.invoices
                .Where(i => i.Create_At.Date == date.Date && i.InvoiceStatusId == statusId)
                .Include(i => i.PaymentMethod)
                .Include(i => i.customers)
                .Include(i => i.InvoiceStatus)
                .Include(i => i.address)
                .Include(i => i.invoiceItems)
                    .ThenInclude(ii => ii.Products)
                        .ThenInclude(ii => ii.images)
                 .Include(i => i.invoiceItems)
                       .ThenInclude(pp => pp.orderItemOptions)       
                .OrderByDescending(i => i.Create_At)
                .ToListAsync();
        }
        public async Task<Dictionary<int, double>> GetMonthlyRevenueAsync(int year) {
            var data = await _context.invoices
                .Where(i => i.IsPayment == true && i.Create_At.Year == year)
                .GroupBy(i => i.Create_At.Month)
                .Select(g => new {
                    Month = g.Key,
                    Total = g.Sum(x => x.TotalAmount)
                })
                .ToListAsync();

            // Tạo dictionary đủ 12 tháng (tháng nào không có hóa đơn → doanh thu = 0)
            var result = Enumerable.Range(1, 12)
                .ToDictionary(m => m, m => data.FirstOrDefault(x => x.Month == m)?.Total ?? 0);

            return result;
        }

        // ✅ Doanh thu theo từng ngày trong tháng
        public async Task<Dictionary<int, double>> GetDailyRevenueAsync(int year, int month) {
            var data = await _context.invoices
                .Where(i => i.IsPayment == true &&
                            i.Create_At.Year == year &&
                            i.Create_At.Month == month)
                .GroupBy(i => i.Create_At.Day)
                .Select(g => new {
                    Day = g.Key,
                    Total = g.Sum(x => x.TotalAmount)
                })
                .ToListAsync();

            // Lấy số ngày trong tháng (vd: 31)
            int daysInMonth = DateTime.DaysInMonth(year, month);

            var result = Enumerable.Range(1, daysInMonth)
                .ToDictionary(d => d, d => data.FirstOrDefault(x => x.Day == d)?.Total ?? 0);

            return result;
        }

        public async Task<Invoices?> GetInvoiceForCart(int invoiceId) {
            return await _context.invoices.Include(x => x.invoiceItems).FirstOrDefaultAsync(s => s.InvoiceId == invoiceId);
        }
        public async Task<List<Invoices>> GetAllInvoiceByDay(DateTime date) {
            var start = date.Date;
            var end = start.AddDays(1);

            return await _context.invoices
                .Where(item => item.Create_At >= start && item.Create_At < end)
                .ToListAsync();
        }
    }
}
