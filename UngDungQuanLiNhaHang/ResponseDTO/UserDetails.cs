namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class UserDetails {
        public int userId { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? access_token { get; set; }
        public string? refresh_token { get; set; }
    }
}
