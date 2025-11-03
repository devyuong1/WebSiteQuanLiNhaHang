using Microsoft.AspNetCore.SignalR;
using UngDungQuanLiNhaHang.Hubs;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class OrderNotificationService : IOrderNotificationService {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderNotificationService(IHubContext<OrderHub> hubContext) {
            _hubContext = hubContext;
        }

        // Gửi thông báo đơn hàng mới đến user cụ thể
        public async Task NotifyNewOrder(InvoiceForAdminResponse order) {
            await _hubContext.Clients
                .Group($"orderNotifi")
                .SendAsync("ReceiveNewOrder", order);
        }

        // Gửi thông báo cập nhật trạng thái đơn hàng
        public async Task NotifyOrderStatusChange(InvoiceForAdminResponse order) {
            await _hubContext.Clients
                .Group($"user_{order.employeeId}")
                .SendAsync("ReceiveOrderUpdate", order);
        }

        // Gửi thông báo đến tất cả users (ví dụ: admin dashboard)
        public async Task NotifyAllUsers(string message) {
            await _hubContext.Clients.All
                .SendAsync("ReceiveNotification", message);
        }
    }
}
