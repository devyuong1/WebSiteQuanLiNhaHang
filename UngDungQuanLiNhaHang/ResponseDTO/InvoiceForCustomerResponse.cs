namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceForCustomerResponse {
        public int invoiceId { get; set; }
        public double totalAmount { get; set; }
        public DateTime create_At { get; set; }
        public int invoiceStatusId { get; set; }
        public string? statusName { get; set; }

        public List<InvoiceItemResponse> invoiceItems { get; set; } = [];
    }
}
