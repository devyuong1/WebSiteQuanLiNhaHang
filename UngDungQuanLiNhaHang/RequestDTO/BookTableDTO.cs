using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class BookTableDTO {
        public int bookTableId { get; set; }
        public DateTime bookingDate { get; set; }
        public int numberOfGuests { get; set; }
        public int tableId { get; set; }
       

    }
}
