using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class InvoiceOffLineDTO {
        public int totalQuantity { get; set; }
        public double totalAmount { get; set; }
        public int tableId { get; set; }
        public List<InvoiceItemDTO> invoiceItems { get; set; } = new List<InvoiceItemDTO>();
    }
}
