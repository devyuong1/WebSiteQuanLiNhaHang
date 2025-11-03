using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductOptionsDTO {
        public int id { get; set; }
        public double quantity { get; set; }
        public int ingredientId { get; set; }
        public string optionName { get; set; } = null!;
        public double price { get; set; }
        public string unit { get; set; } = null!;
    }
}
