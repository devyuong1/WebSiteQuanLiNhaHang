namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class ProductResponse {
        public int productId { get; set; }
        public required string productName { get; set; }
        public string description { get; set; } = "";
        public double price { get; set; }
        public double priceSale { get; set; }
        public int quantity { get; set; }
        public int sold { get; set; }
        public double averageRating { get; set; } = 5;
        public int TotalReviews { get; set; } = 1;
        
        public List<string> images { get; set; } = new List<string>();
        public string? recipes { get; set; }
        public List<ProductOptionResponse> productOptions { get; set; } = [];
        public List<ProductReviewResponse> productReviews { get; set; } = [];

    } 
}
