using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class PurchaseInvoiceItem {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseInvoiceItemID { get; set; }  
        public double Quantity { get; set; }
        public double Price { get; set; }
        public required string Unit {  get; set; }

        public int purchaseInvoiceId { get; set; }
        public PurchaseInvoice? purchaseInvoice { get; set; }
        public int ingredientId { get; set; }
        public Ingredient? ingredient { get; set; }
    }
}
