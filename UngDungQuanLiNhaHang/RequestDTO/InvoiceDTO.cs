using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class InvoiceDTO {
        public int invoiceId { get; set; }
        public int totalQuantity { get; set; }
        public double totalAmount { get; set; }
        public bool isPayment { get; set; } // true: da thanh toan, false: chua thanh toan
        public bool invoiceType { get; set; } // true: tai cho, false: online
        public int customerId { get; set; }
        public int paymentMethodId { get; set; }
        public int invoiceStatusId { get; set; }
        public int addressId { get; set; }
        public List<InvoiceItemDTO> invoiceItems { get; set; } = new List<InvoiceItemDTO>();
    }
}
