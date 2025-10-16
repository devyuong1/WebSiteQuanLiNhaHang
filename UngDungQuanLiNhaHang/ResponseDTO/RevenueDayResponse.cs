namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class RevenueDayResponse {
        public int year { get; set; }
        public int month { get; set; }
        public Dictionary<int, double> dailyRevenue { get; set; } = new Dictionary<int, double>();
    }
}
