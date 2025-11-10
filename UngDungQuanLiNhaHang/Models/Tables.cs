using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Tables {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
        
        public ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();
        public ICollection<BookTable> BookTables { get; set; } = new List<BookTable>();
    }
}
