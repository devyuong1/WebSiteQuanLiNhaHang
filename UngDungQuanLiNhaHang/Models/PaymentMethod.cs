using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class PaymentMethod {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentMethodId { get; set; }
        public required string PaymentMethodName { get; set; }
        public ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();
    }
}
