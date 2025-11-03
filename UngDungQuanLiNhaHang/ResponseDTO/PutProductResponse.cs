using UngDungQuanLiNhaHang.RequestDTO;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class PutProductResponse {
        public int productId {  get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double priceSale { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public string image { set; get; }
        public List<ProductOptionsDTO> productOptionsDTO { get; set; } = [];
        public List<RecipeDTO> recipeDTO { get; set; } = [];
    }
}
