using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Address {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public required string Province { get; set; }
        public required string District { get; set; }
        public required string Hamlet { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public bool IsDefault { get; set; } = true;
        public int? restaurantId { get; set; }
        public Restaurants? restaurants { get; set; }
        public int? employeeId { get; set; }
        public Employees? employees { get; set; }
        public int? customerId { get; set; }
        public Customers? customers { get; set; }
        public int? supplierId { get; set; }
        public Suppliers? suppliers { get; set; }

        public ICollection<Invoices> invoices { get; set; } = new List<Invoices>();
    }
}
