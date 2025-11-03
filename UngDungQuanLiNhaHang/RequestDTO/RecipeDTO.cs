namespace UngDungQuanLiNhaHang.RequestDTO {
    public class RecipeDTO {
        public int recipeId {  get; set; }
        public required int ingredientId { get; set; }
        public double quantity { get; set; }
        public required string unit { get; set; }
       
    }
}
