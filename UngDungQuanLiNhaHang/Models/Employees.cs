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


        public int addressId { get; set; }
        public Address? address { get; set; }

        public int restaurantId { get; set; }
        public Restaurants? restaurants { get; set; }

        public int roleId { get; set; }
        public Roles? roles { get; set; }
        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<RefreshTokens> RefreshTokens { get; set; } = new List<RefreshTokens>();
    }
}
