using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class CartItems {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int cartId { get; set; }
        public Carts? Carts { get; set; }
        public int productId { get; set; }
        public Products? Products { get; set; }
    }
}
