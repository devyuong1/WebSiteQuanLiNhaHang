using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class PurchaseInvoiceItemDTO {

        public double quantity { get; set; }
        public double price { get; set; }
        public required string unit { get; set; }


        public int ingredientId { get; set; }
    }
        
}
