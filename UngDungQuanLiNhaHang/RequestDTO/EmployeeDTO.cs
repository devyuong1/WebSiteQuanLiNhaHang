using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class EmployeeDTO {
        public int employeeId { get; set; }
        public required string fullname { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
        public AddressDTO? address { get; set; }
        public int restaurantId { get; set; }
        public int roleId { get; set; }
        
    }
}
