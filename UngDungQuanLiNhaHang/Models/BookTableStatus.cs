using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class BookTableStatus {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookTableStatusId { get; set; }
        [Required]
        public required string status { get; set; }
        public ICollection<BookTable> BookTables { get; set; } = new List<BookTable>();
    }
}
