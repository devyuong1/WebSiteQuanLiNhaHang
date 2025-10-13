namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceForCustomerResponse {
        public int invoiceId { get; set; }
        public int totalQuantity { get; set; }
        public double totalAmount { get; set; }
        public bool isPayMent { get; set; } // true: da thanh toan, false: chua thanh toan
        public bool invoiceType { get; set; } // true: tai cho, false: online
        public DateTime create_At { get; set; }
        public required string paymentMethodName { get; set; }
        public int invoiceStatusId { get; set; }

        public List<InvoiceItemResponse> invoiceItems { get; set; } = [];
    }
}
