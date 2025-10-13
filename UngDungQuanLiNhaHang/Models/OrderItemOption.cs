using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class OrderItemOption {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemOptionId { get; set; }
        public required string OrderItemOptionName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public required int productOptionId { get; set; }
        public int InvoiceItemId { get; set; }

        [ForeignKey("InvoiceItemId")]
        public InvoiceItems? InvoiceItem { get; set; }
        
    }
}
