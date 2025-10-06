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
        public int PurchaseInvoiceId { get; set; }
        [ForeignKey("PurchaseInvoiceId")]

        public PurchaseInvoice? PurchaseInvoice { get; set; }
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]

        public Ingredient? Ingredient { get; set; }
    }
}
