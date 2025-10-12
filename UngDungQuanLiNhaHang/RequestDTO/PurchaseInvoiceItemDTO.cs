using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class PurchaseInvoiceItemDTO {
        public int ingredientId { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
        public required string unit { get; set; }

        
    }
        
}
