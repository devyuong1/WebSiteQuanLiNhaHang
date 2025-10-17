namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CartItemOptionResponse {
        public int id { get; set; }
        public required string optionName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        
    }
}
