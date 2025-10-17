using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class CartItemOption {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string OptionName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int productOptionId { get; set; }
        public int CartItemId { get; set; }
        [ForeignKey("CartItemId")]
        public CartItems? CartItems { get; set; }
    }
}
