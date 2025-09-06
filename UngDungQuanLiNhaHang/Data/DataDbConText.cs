using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Data {
    public class DataDbConText : DbContext {

        public DataDbConText(DbContextOptions<DataDbConText> options) :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging(); // Bật chi tiết lỗi
        }

        public DbSet<Address> addresses { get; set; }
        public DbSet<Restaurants> restaurants { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Categorys> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Carts> carts { get; set; }
        public DbSet<CartItems> cartItems { get; set; }
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<InvoiceStatus> invoicesStatus { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }
        public DbSet<InvoiceItems> invoicesItems { get; set; }
        public DbSet<Images> images { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }

        public DbSet<PurchaseInvoice> purchaseInvoice { get; set; }
        public DbSet<PurchaseInvoiceItem> purchaseInvoiceItem { get; set; }
        public DbSet<ProductReviews> productReviews { get; set; }
        public DbSet<Recipes> recipes { get; set; }


    }
}
