using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Customers {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone {  get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public int roleId { get; set; }
        public Roles? role { get; set; }
        public int? cartId { get; set; }
        public Carts? cart { get; set; }
        public ICollection<Address> addresses { get; set; } = [];
        public ICollection<Invoices> invoices { get; set; } = new List<Invoices>();
        public ICollection<ProductReviews> productReviews { get; set; } = new List<ProductReviews>();
        public ICollection<RefreshTokens> refreshTokens { get; set; } = new List<RefreshTokens>();
    }
}
