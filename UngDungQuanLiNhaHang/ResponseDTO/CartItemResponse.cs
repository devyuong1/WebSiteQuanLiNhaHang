namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CartItemResponse {
        public int cartItemId { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productImage { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public List<CartItemOptionResponse> options { get; set; } = new List<CartItemOptionResponse>();
    }
}
