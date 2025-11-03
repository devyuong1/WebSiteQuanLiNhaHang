namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class purchaseInvoiceDashboard {
        public int totalPurchaseInvoices { get; set; }      // Tổng số đơn mua hàng
        public double totalAmountSpent { get; set; }        // Tổng tiền đã chi
        public double totalDebtAmount { get; set; }         // Tong tien chua thanh toan
    }
}
