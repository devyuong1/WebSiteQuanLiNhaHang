using System.ComponentModel.DataAnnotations.Schema;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class ProductReviewDTO {
        public int productReviewId { get; set; }
        public int  rating { get; set; }
        public required string comment { get; set; }
        public int invoiceId { get; set; }
        public int productId { get; set; }
    }
}
