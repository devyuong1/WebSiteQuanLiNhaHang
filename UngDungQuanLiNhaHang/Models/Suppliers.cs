using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Suppliers {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        public required string SupplierName {get; set;}
        public required string Phone {  get; set;}
        public required string Email { get; set;}

        public int addressID { get; set;}
        public Address? address { get; set;}

        public ICollection<PurchaseInvoice> purchaseInvoices { get; set;} = new List<PurchaseInvoice>();
    }
}
