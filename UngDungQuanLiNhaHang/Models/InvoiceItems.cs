using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class InvoiceItems {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


        public int productId { get; set; }
        public Products? products { get; set; }

        public int invoiceId { get; set; }
        public Invoices? invoices { get; set; }
    }
}
