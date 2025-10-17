using System.Text.Json.Serialization;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class LoginDTO {
        [JsonPropertyName("Email")]
        public required string Email { get; set; }
        [JsonPropertyName("Password")]
        public required string Password { get; set; }
    }
}
