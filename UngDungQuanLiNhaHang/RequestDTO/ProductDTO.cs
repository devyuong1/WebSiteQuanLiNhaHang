using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductDTO {
        public int productId { get; set; }
        public required string productName { get; set; }
        public required string description { get; set; }
        public double price { get; set; }
        public double priceSale { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        

        public List<ProductOptionsDTO> productOptionsDTO { get; set; } = [];
        public List<RecipeDTO> recipeDTO { get; set; } = [];


    }
}
