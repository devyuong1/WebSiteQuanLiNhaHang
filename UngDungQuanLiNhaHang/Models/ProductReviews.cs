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

        public int customerId { get; set; }
        public Customers? customers { get; set; }
        public int invoiceId { get; set; }
        public Invoices invoices { get; set; }

        public int productId { get; set; }
        public Products? products { get; set; }
    }
}
