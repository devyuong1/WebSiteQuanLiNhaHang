using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Recipes {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
        public double Quantity { get; set; }
        public required string Unit {  get; set; }
        public bool isDelete { get; set; } = false;
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]

        public Ingredient? Ingredient { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Products? Products { get; set; }
    }
}
