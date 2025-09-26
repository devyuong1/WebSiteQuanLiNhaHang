namespace UngDungQuanLiNhaHang.RequestDTO {
    public class IngredientDTO {
        public int ingredientId { get; set; }
        public required string ingredientName { get; set; }
        public double quantity { get; set; }
        public double minQuantity { get; set; }
        public double price { get; set; }
        public required string unit { get; set; }
        public bool isActive { get; set; } = true;
    }
}
