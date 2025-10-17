namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CustomerResponse {
        public int customerId { get; set; }
        public string? fullName { get; set; } 
        public string? email { get; set; } 
        public string? phone { get; set; } 
        public string? access_token { get; set; }
        public string? refresh_token { get; set; }
        public string role { get; set; }
        public List<AddressResponse> address { get; set; } = new List<AddressResponse?>();
    }
}
