namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class CategoryResponse {
        public int categoryId { get; set; }
        public required string categoryName { get; set; }
        public bool isActive { get; set; } = true;
    }
}
