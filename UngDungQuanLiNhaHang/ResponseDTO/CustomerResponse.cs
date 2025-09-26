namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CustomerResponse {
        public int customerId { get; set; }
        public string fullName { get; set; } = null!;
        public string email { get; set; } = null!;
        public string access_token { get; set; } = null!;
        public string refresh_token { get; set; } = null!;

        public List<AddressResponse?> address { get; set; } = new List<AddressResponse?>();
    }
}
