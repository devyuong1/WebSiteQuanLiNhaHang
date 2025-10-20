namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceItemResponse {
        public required string productName { get; set; }
        public required string productImage { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        
        public List<InvoiceItemOptionRespon> options { get; set; } = new List<InvoiceItemOptionRespon>();
    }
}
