using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class CartItems {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Carts? Carts { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Products? Products { get; set; }
        public ICollection<CartItemOption> CartItemOptions { get; set; } = new List<CartItemOption>();
    }
}
