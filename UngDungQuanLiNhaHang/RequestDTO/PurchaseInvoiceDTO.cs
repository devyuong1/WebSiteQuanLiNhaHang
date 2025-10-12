namespace UngDungQuanLiNhaHang.RequestDTO {
    public class PurchaseInvoiceDTO {
        public int purchaseInvoiceId { get; set; }
        public double totalamount { get; set; }
        public DateTime create_At { get; set; }
        public bool isPayment { get; set; }
        public int supplierId { get; set; }
        public int employeeId { get; set; }
        public required List<PurchaseInvoiceItemDTO> items { get; set; }
    }
}
