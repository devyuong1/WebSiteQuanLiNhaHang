namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ChangePassword {
        public int CustomerId { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        
    }
}
