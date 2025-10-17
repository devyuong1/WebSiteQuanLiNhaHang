namespace UngDungQuanLiNhaHang.RequestDTO {
    public class AddItemCartDTO {
        
        public int productid { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public List<CartItemOptionDTO> cartItemOptions { get; set; } = new List<CartItemOptionDTO>();
    }
}
