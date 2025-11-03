using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;
using System.Security.Claims;
namespace UngDungQuanLiNhaHang.Hubs {
    [Authorize]
    public class OrderHub : Hub {
        public override async Task OnConnectedAsync() {
            await Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        // Được gọi khi client ngắt kết nối
        public override async Task OnDisconnectedAsync(Exception? exception) {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if ( !string.IsNullOrEmpty(userId) ) {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
                Debug.WriteLine($"🔌 User {userId} disconnected and removed from group.");
            }
            await base.OnDisconnectedAsync(exception);
        }

        // Method để client join vào group theo userId
        public async Task JoinUserGroup() {
            try {
               

                //var user = Context.User;

                //if ( user == null || !user.Identity.IsAuthenticated ) {
                //    Debug.WriteLine("❌ User chưa đăng nhập, không thể tham gia nhóm.");
                //    return;
                //}

                //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //if ( string.IsNullOrEmpty(userId) ) {
                //    Debug.WriteLine("❌ Không tìm thấy userId trong token." + user.ToString());
                //    return;
                //}

                // Dòng gây lỗi khả năng cao nhất:
                await Groups.AddToGroupAsync(Context.ConnectionId, $"orderNotifi");

                Debug.WriteLine($"✅ User successfully added to group.");
            }
            catch ( Exception ex ) {
                // Ghi lại lỗi chi tiết nhất vào Debug Output
                Debug.WriteLine("---------------------------------------------");
                Debug.WriteLine($"FATAL EXCEPTION in JoinUserGroup: {ex.ToString()}");
                Debug.WriteLine("---------------------------------------------");

                // Ném lỗi lại để nó có thể được bắt bởi tầng trên
                throw;
            }
        }

        // Method để client rời group
        public async Task LeaveUserGroup(string userId) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
        }
    }
}
