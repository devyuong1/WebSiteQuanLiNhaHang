using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public string? Note { get; set; }
        public int? customerId { get; set; }
        [ForeignKey("customerId")]
        [JsonIgnore]
        public Customers? customers { get; set; }
        public int? tableId { get; set; }
        [JsonIgnore]
        [ForeignKey("tableId")]
        public Tables? tables { get; set; }
        public int employeeId { get; set; } = 0;
        public string? HangfireJobId { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        [JsonIgnore]
        public PaymentMethod? PaymentMethod { get; set; }
        public int InvoiceStatusId { get; set; }
        [ForeignKey("InvoiceStatusId")]
        [JsonIgnore]
        public InvoiceStatus? InvoiceStatus { get; set; }
        [JsonIgnore]
        public ICollection<ProductReviews> productReviews { get; set; } = new List<ProductReviews>();
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        [JsonIgnore]
        public Address? address { get; set; }
        [JsonIgnore]
        public ICollection<InvoiceItems> invoiceItems { get; set; }  = new List<InvoiceItems>();


    }
}
