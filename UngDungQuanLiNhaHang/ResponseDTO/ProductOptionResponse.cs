namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class ProductOptionResponse {
        public int productOptionId { get; set; }
        public required string optionName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

    }
}
