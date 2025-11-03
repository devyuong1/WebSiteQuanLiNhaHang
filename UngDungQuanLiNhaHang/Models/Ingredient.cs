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
        public required string  UsageUnit { get; set; }
        public double ConversionRate { get; set; }
        public required string Unit {  get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Recipes> Recipes { get; set; } = [];
        public ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set;} = [];
        public ICollection<ProductOptions> ProductOptions { get; set; } = [];
    }
}
