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
        public  string? Street { get; set; }
        public  string? HouseNumber { get; set; }
        public bool IsDefault { get; set; } = true;
        
        public Restaurants? Restaurant { get; set; }
        public ICollection<Customers> customers { get; set; } = new List<Customers>();
        public ICollection<Employees> employees { get; set; } = new List<Employees>();

        
        public ICollection<Suppliers> suppliers { get; set; } = new List<Suppliers>();

        public ICollection<Invoices> invoices { get; set; } = new List<Invoices>();
    }
}
