using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class PurchaseInvoice {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseInvoiceId { get; set; }
        public double Totalamount { get; set; }
        
        public DateTime Create_At { get; set; }
        public bool IsPayment {  get; set; }
        public int supplierId { get; set; }
        public Suppliers? suppliers { get; set; }
        public ICollection<PurchaseInvoiceItem> purchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
        public int employeeId { get; set; }
        public Employees? employees { get; set; }
    }
}
