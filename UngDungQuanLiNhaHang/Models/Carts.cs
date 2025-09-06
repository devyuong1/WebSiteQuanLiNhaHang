using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Carts {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalAmount { get; set; }

        public int customerId { get; set; }
        public Customers? Customers { get; set; }
        public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}
