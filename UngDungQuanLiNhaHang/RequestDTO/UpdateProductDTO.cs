namespace UngDungQuanLiNhaHang.RequestDTO {
    public class UpdateProductDTO {
        public int productId { get; set; }
        public required string productName { get; set; }
        public required string description { get; set; }
        public double price { get; set; }
        public double priceSale { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        
        public ICollection<RecipeDTO> recipeDTO { get; set; } = [];
        public ICollection<ProductOptionsDTO> productOptionsDTO { get; set; } = [];
    }
}
