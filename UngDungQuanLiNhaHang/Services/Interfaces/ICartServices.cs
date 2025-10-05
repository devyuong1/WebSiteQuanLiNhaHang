
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ICartServices {
       
        public Task<ApiResponse<bool>> RemoveFromCart(int customerId, int foodId);
        public Task<ApiResponse<bool>> UpdateCartItem(int customerId, AddItemCartDTO addItemCartDTO);
        public Task<ApiResponse<CartResponse>> GetCartItems(int customerId);
    }
}
