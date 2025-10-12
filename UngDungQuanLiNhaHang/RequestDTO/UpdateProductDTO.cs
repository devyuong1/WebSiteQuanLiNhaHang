namespace UngDungQuanLiNhaHang.RequestDTO {
    public class UpdateProductDTO {
        public int productId { get; set; }
        public required string productName { get; set; }
        public required string description { get; set; }
        public double price { get; set; }
        public double priceSale { get; set; }
        public int quantity { get; set; }
        public int CategoryId { get; set; }
        public List<UpdateImagesFileDTO> files { get; set; } = new List<UpdateImagesFileDTO>();
        public ICollection<RecipeDTO> recipes { get; set; } = [];
        public ICollection<ProductOptionsDTO> productOptions { get; set; } = [];
    }
}
