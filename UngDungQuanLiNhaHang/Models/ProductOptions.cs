using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class ProductOptions {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOptionId { get; set; }
        public required string OptionName { get; set; }
        public double OptionValue { get; set; }
        public required string Unit { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products? Product { get; set; }
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }
       
        
    }
}
