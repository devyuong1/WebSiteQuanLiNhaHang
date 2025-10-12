namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class ProductReviewResponse {
        public int productReviewId { get; set; }
        public required string userName { get; set; }
        public int rating { get; set; }
        public required string comment { get; set; }
        public DateTime create_At { get; set; }
    }
}
