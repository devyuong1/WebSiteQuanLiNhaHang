using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class InvoiceStatus {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceStatusId { get; set; }
        public required string InvoiceStatusName { get; set; }
        public required string Description { get; set; }
        public ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();
    }
}
