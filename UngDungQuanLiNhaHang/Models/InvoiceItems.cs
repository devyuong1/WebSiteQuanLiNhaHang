using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class InvoiceItems {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Products? Products { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]

        public Invoices? Invoices { get; set; }
    }
}
