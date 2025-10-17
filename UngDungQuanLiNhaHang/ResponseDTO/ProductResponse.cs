namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class ProductResponse {
        public int productId { get; set; }
        public required string productName { get; set; }
        public double price { get; set; }
        public double priceSale { get; set; }
        public int sold { get; set; }
        public double averageRating { get; set; } = 5;
        public string image { get; set; } = "";


    } 
}
