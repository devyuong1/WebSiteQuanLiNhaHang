using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class BookTableDTO {
        public DateTimeOffset bookingDate { get; set; } 
        public int numberOfGuests { get; set; }
        public int tableId { get; set; }


    }
}
