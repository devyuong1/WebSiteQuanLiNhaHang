using UngDungQuanLiNhaHang.RequestDTO;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceItemDTO {
        public int invoiceId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int productId { get; set; }

        public List<OrderItemOptionDTO> orderOptions { get; set; } = new List<OrderItemOptionDTO>();
    }
}
