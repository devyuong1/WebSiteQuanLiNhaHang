namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CartResponse {
        public int cartId { get; set; }
        public double totalAmount { get; set; }
        public List<CartItemResponse> cartItems { get; set; } = new List<CartItemResponse>();
    }
}
