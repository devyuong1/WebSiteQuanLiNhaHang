using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class BookTableDTO {
        public DateTime bookingDate { get; set; } = DateTime.UtcNow;
        public int numberOfGuests { get; set; }
        public int tableId { get; set; }


    }
}
