
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ICartServices {
         Task<ApiResponse<bool>> RemoveFromCart(int customerId, int cartItemId);
         Task<ApiResponse<bool>> UpdateCartItem(int customerId, AddItemCartDTO addItemCartDTO);
         Task<ApiResponse<CartResponse>> GetCartItems(int customerId);

        Task<ApiResponse<bool>> UpdateQuantityCartItem(int customerId,int cartItemId, int quantity);
        Task<ApiResponse<bool>> UpdateQuantityCartOption(int customerId, int cartItemId,int cartOptionId, int quantity);
        Task<ApiResponse<bool>> DeleteCartItemOption(int customerId, int cartItemId,int cartOptionId);
    }
}
