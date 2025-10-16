namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class RevenueMonth {
        public int year { get; set; }
        public Dictionary<int, double> monthlyRevenue { get; set; } = new Dictionary<int, double>();
    }
}
