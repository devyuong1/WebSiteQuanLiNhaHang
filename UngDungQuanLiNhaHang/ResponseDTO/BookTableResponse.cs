namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class BookTableResponse {
        public int bookTableId { get; set; }
        public DateTime bookingDate { get; set; }
        public int numberOfPeople { get; set; }
        public double depositAmount { get; set; }
        public bool isDepositPaid { get; set; }
        public int statusId { get; set; }
        public string statusName { get; set; } = string.Empty;
        public int tableId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
