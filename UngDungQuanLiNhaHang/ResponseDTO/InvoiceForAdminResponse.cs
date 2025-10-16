using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class InvoiceForAdminResponse {
        public int invoiceId { get; set; }
        public int totalQuantity { get; set; }
        public double totalAmount { get; set; }
        public DateTime create_At { get; set; }
        public bool isPayment { get; set; } // true: da thanh toan, false: chua thanh toan
        public bool invoiceType { get; set; } // true: tai cho, false: online
        public string? note { get; set; }
        public int? customerId { get; set; }
        public string? customerName { get; set; }
        public int? tableId { get; set; }
        public int employeeId { get; set; } = 0;
        public string? paymentMethodName { get; set; }
        public string? invoiceStatusName { get; set; }
        public List<ProductReviewResponse> productReviews { get; set; } = new List<ProductReviewResponse>();
        public string? addressDetail { get; set; }
        public List<InvoiceItemResponse> invoiceItems { get; set; } = new List<InvoiceItemResponse>();
    }
}
