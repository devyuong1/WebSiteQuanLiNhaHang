namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductPageDTO {
        public int page { get; set; } = 1;
        public int orderBy { get; set; } 
        public string? name { get; set; }
        public int? categoryId { get; set; }

    }
}
