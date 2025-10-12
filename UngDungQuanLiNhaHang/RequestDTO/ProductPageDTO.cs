namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductPageDTO {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 12;
        public string? Search { get; set; }
        public int? CategoryId { get; set; }

    }
}
