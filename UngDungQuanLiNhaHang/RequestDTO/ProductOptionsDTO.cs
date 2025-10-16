using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductOptionsDTO {
        public int Id { get; set; }
        public int quantity { get; set; }
        public int IngredientId { get; set; }

        public string optionName { get; set; } = null!;
        public double optionValue { get; set; }
        public double price { get; set; }
        public string unit { get; set; } = null!;
    }
}
