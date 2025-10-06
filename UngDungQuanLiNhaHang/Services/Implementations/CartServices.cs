using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CartServices(CartRepo cartRepo,
        TransactionRepo transactionRepo,
        ProductRepo productRepo
        ) : ICartServices {
       
       

        public async Task<ApiResponse<CartResponse>> GetCartItems(int customerId) {
            var cart = await cartRepo.GetCartByCustomerId(customerId);
            if ( cart == null || cart.TotalQuantity <= 0 ) {
                return ApiResponse<CartResponse>.FailResponse("Cart not found");
            }
            var cartResponse = new CartResponse {
                cartId = cart.CartId,
                totalAmount = cart.TotalAmount,
                totalQuantity = cart.TotalQuantity,
                cartItems= cart.CartItems.Select(ci => new CartItemResponse {
                     cartItemId = ci.CartItemId,
                     productId = ci.ProductId,
                     productName = ci.Products!.ProductName,
                     quantity = ci.Quantity,
                     price = ci.Price,
                     productImage = ci.Products.images.First().ImagesUrl
                }).ToList()
            };
            return ApiResponse<CartResponse>.SuccessResponse(cartResponse);
        }

        public async Task<ApiResponse<bool>> RemoveFromCart(int customerId, int cartItemId) {
            var cart = await cartRepo.GetCart(customerId);
            if ( cart == null ) {
                return ApiResponse<bool>.FailResponse("Cart not found");
            }
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if ( cartItem == null ) {
                return ApiResponse<bool>.FailResponse("Cart item not found");
            }
            try {
                               await transactionRepo.BeginTransactionAsync();
                cart.TotalAmount -= cartItem.Quantity * cartItem.Price;
                cart.TotalQuantity -= 1;
                cart.CartItems.Remove(cartItem);
                cartRepo.UpdateCart(cart);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true,"Xoá Thành Công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }}

        public async Task<ApiResponse<bool>> UpdateCartItem(int customerId, AddItemCartDTO addItemCartDTO) {
            var cart = await cartRepo.GetCartByCustomerId(customerId);
            if ( cart == null ) {
                return ApiResponse<bool>.FailResponse("Cart not found");
            }
            var product = await productRepo.IsProductExists(addItemCartDTO.productid);
            if ( !product ) {
                return ApiResponse<bool>.FailResponse("Product not found");
            }
            // neu co san pham trong gio hang thi cap nhat so luong
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == addItemCartDTO.productid);
            try {
                await transactionRepo.BeginTransactionAsync();
                if ( cartItem != null ) {
                    cartItem.Quantity = addItemCartDTO.quantity;
                    cartItem.Price = addItemCartDTO.price;
                    cart.TotalAmount = cart.TotalAmount - ( cartItem.Quantity * cartItem.Price ) + addItemCartDTO.quantity * addItemCartDTO.price;
                }
                // neu chua co san pham trong gio hang thi them moi
                else {
                    CartItems items = new() {
                        Price = addItemCartDTO.price,
                        ProductId = addItemCartDTO.productid,
                        Quantity = addItemCartDTO.quantity,
                    };
                    cart.TotalQuantity += 1;
                    cart.TotalAmount += addItemCartDTO.quantity * addItemCartDTO.price;
                    cart.CartItems.Add(items);
                }
                cartRepo.UpdateCart(cart);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true,"Update Thành Công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }
        }
    }
}
