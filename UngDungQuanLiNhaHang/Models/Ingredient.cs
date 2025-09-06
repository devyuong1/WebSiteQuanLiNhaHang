using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Ingredient {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }
        public required string IngredientName {  get; set; }

        public double Quantity { get; set; }

        public double MinQuantity { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Recipes> recipes { get; set; } = new List<Recipes>();
        public ICollection<PurchaseInvoiceItem> purchaseInvoiceItems { get; set;} = new List<PurchaseInvoiceItem>();
    }
}
