using UngDungQuanLiNhaHang.RequestDTO;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class EmployeeResponse {
        public int employeeId { get; set; }
        public required string fullname { get; set; }
        public required string username { get; set; }
        
        public required string phone { get; set; }
        public required string email { get; set; }
        public AddressResponse? address { get; set; }
        
        public int roleId { get; set; }
        public string? roleName { get; set; } 
    }
}
