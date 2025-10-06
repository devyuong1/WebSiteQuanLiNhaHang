using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class ProductReviews {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductReviewId { get; set; }
        public int Rating { get; set; }
        public required string Comment { get; set; }
        public DateTime Create_At { get; set; }
        
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers? Customers { get; set; }

        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]

        public Invoices? Invoices { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Products? Products { get; set; }
    }
}
