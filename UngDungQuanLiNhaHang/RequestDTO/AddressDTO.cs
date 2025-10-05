namespace UngDungQuanLiNhaHang.RequestDTO {
    public class AddressDTO {
        public int customerId { get; set; }
        public int? addressId { get; set; }
        public required string province { get; set; }
        public required string district { get; set; }
        public required string hamlet { get; set; }
        public  string? street { get; set; }
        public  string? houseNumber { get; set; }
        public bool isDefault { get; set; } = true;
    }
}
