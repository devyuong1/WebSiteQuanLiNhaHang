using UngDungQuanLiNhaHang.RequestDTO;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceItemDTO {
        public int invoiceItemId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int productId { get; set; }

        public List<ProductOptionsDTO> productOptions { get; set; } = new List<ProductOptionsDTO>();
    }
}
