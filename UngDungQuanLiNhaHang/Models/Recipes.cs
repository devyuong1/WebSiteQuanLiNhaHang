using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Recipes {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
        public double Quantity { get; set; }
        public required string Unit {  get; set; }

        public int ingredientId { get; set; }
        public Ingredient? ingredient { get; set; }

        public int productId { get; set; }
        public Products? products { get; set; }
    }
}
