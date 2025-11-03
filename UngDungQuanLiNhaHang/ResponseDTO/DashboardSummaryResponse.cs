namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class DashboardSummaryResponse {
        public int totalOrdersToday { get; set; }          // Tổng số đơn hàng hôm nay
        public int cancelledOrders { get; set; }           // Đơn hàng đã hủy
        public int pendingOrders { get; set; }             // Đơn hàng chờ xác nhận
        public int completedOrders { get; set; }
        public double todayRevenue { get; set; }
    }
}
