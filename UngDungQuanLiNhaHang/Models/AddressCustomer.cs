using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class AddressCustomer {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers? Customer { get; set; }
    }
}
