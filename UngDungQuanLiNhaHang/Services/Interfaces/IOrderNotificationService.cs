using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IOrderNotificationService {
        Task NotifyNewOrder(InvoiceForAdminResponse order);
        Task NotifyOrderStatusChange(InvoiceForAdminResponse order);
        Task NotifyAllUsers(string message);
    }
}
