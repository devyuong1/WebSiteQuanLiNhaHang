using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Products {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public double PriceSale { get; set; }
        public int Quantity { get; set; }
        public int SoldCount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Create_At { get; set; } = DateTime.UtcNow;
        public DateTime Update_At { get; set; } = DateTime.UtcNow;
        public double AverageRating { get; set; } = 5;
        public int TotalReviews { get; set; } = 1;
        public int categoryId { get; set; }
        public Categorys? category { get; set; }
        public ICollection<Images> images { get; set; } = new List<Images>();
        public ICollection<Recipes> recipes { get; set; } = new List<Recipes>();

        public ICollection<InvoiceItems> invoiceItems { get; set; } = new List<InvoiceItems>();
        public ICollection<ProductReviews> productReviews { get; set; } = new List<ProductReviews>();
        public ICollection<CartItems> cartItems { get; set; }= new List<CartItems>();
    }
}
