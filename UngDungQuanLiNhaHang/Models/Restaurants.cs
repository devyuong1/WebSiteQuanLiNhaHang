using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Restaurants {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }
        public required string RestaurantName { get; set; }
        public required string Phone {  get; set; }
        public required string Email { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Employees> Employees { get; set; } = new List<Employees>();

    }
}
