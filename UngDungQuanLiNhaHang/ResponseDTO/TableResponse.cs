namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class TableResponse {
        public int tableId {  get; set; }
        public int numberOfPeople { get; set; }
        public string? description { get; set; }
        public bool status { set; get; }
        public int invoiceId { get; set; }
    }
}
