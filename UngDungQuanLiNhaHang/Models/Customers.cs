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
        
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles? Role { get; set; }
       
        public Carts Cart { get; set; }
        public ICollection<AddressCustomer> AddressCustomers { get; set; } = [];
        public ICollection<Invoices> invoices { get; set; } = new List<Invoices>();
        public ICollection<ProductReviews> productReviews { get; set; } = new List<ProductReviews>();
        public ICollection<RefreshTokens> refreshTokens { get; set; } = new List<RefreshTokens>();
        public ICollection<BookTable> bookTables { get; set; } = new List<BookTable>();
    }
}
