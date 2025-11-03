namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class PurchaseInvoiceItemResponse {
        public int purchaseInvoiceItemId { get; set; }
        public int ingredientId { get; set; }
        public string? ingredientName { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
        public required string unit { get; set; }
        
    }
}
