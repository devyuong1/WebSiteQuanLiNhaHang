using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Invoices {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Create_At { get; set; } 
        public bool IsPayment { get; set; } // true: da thanh toan, false: chua thanh toan
        public bool InvoiceType {  get; set; } // true: tai cho, false: online
        public int? customerId { get; set; }
        public Customers? customers { get; set; }
        public int? tableId { get; set; }
        public Tables? tables { get; set; }
        public int employeeId { get; set; } = 0;

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod? PaymentMethod { get; set; }
        public int InvoiceStatusId { get; set; }
        [ForeignKey("InvoiceStatusId")]
        public InvoiceStatus? InvoiceStatus { get; set; }
        public ProductReviews? productReviews { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]

        public Address? address { get; set; }
        public ICollection<InvoiceItems> invoiceItems { get; set; }  = new List<InvoiceItems>();


    }
}
