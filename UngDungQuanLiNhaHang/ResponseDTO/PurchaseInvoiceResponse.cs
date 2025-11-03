namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class PurchaseInvoiceResponse {
        public int purchaseInvoiceId { get; set; }
        public double totalamount { get; set; }
        public DateTime create_At { get; set; }
        public bool isPayment { get; set; }
        public string? supplierName { get; set; }
        public string? employeeName { get; set; }
        public int supplierId { get; set; }
        
        public List<PurchaseInvoiceItemResponse> purchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItemResponse>();
    }
}
