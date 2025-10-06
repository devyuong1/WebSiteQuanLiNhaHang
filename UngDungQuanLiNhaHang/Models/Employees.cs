using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Employees {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public required string Fullname { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

        public bool IsActive { get; set; } = true;
        
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public int? RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]

        public Restaurants? Restaurant { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]

        public Roles? Role { get; set; }
        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<RefreshTokens> RefreshTokens { get; set; } = new List<RefreshTokens>();
    }
}
