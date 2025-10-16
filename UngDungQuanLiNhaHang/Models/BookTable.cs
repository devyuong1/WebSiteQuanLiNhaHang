using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class BookTable {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookTableId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        
        public double DepositAmount { get; set;}
        public bool IsDepositPaid { get; set; }
        public DateTime Create_At { get; set; }
        public int TableId { get; set; }
        public Tables? Tables { get; set; }
        public int customerId { get; set; }
        public Customers? Customers { get; set; }
        public int bookTableStatusId { get; set; }
        [ForeignKey("bookTableStatusId")]
        public BookTableStatus? BookTableStatus { get; set; }
    }
}
