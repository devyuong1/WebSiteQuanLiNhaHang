namespace UngDungQuanLiNhaHang.RequestDTO {
    public class CategoryDTO {
        public int categoryId { get; set; }
        public required string categoryName { get; set; }
        public bool isActive { get; set; } = true;
    }
}
