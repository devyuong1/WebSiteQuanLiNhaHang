
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface CartServices {
        public Task<bool> AddToCart(AddItemCartDTO addItemCartDTO);
        public Task<bool> RemoveFromCart(int customerId, int foodId);
        public Task<bool> UpdateCartItem(int customerId, AddItemCartDTO addItemCartDTO);
        public Task<ApiResponse<CartResponse>> GetCartItems(int customerId);
    }
}
