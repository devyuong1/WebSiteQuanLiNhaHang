using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Roles {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Employees> Employees { get; set; } = new List<Employees>();
        public ICollection<Customers> Customers { get; set; } = new List<Customers>();
    }
}
