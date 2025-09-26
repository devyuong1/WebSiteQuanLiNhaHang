namespace UngDungQuanLiNhaHang.RequestDTO {
    public class CustomerDTO {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public required string PasswordHash { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
