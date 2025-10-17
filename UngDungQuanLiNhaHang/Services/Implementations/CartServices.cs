using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;
using CartItemOption = UngDungQuanLiNhaHang.Models.CartItemOption;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CartServices(CartRepo cartRepo,
        TransactionRepo transactionRepo,
        ProductRepo productRepo,
        ProductOptionRepo productOptionRepo
        ) : ICartServices {
       
       

        public async Task<ApiResponse<CartResponse>> GetCartItems(int customerId) {
            var cart = await cartRepo.GetCartByCustomerId(customerId);
            if ( cart == null ) {
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
            var cart = await cartRepo.GetCart(customerId);
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
                   
                    cart.TotalAmount = cart.TotalAmount + addItemCartDTO.quantity * addItemCartDTO.price;
                    cartItem.Quantity += addItemCartDTO.quantity;
                    cartItem.Price = addItemCartDTO.price;
                    foreach ( var item in addItemCartDTO.cartItemOptions ) {
                        var productOption = await productOptionRepo.GetById(item.productOptionId);
                        if (productOption == null) {
                            return ApiResponse<bool>.FailResponse("ProductOption not found");
                        }
                        var option = cartItem.CartItemOptions.Where(s => s.productOptionId == item.productOptionId).FirstOrDefault();
                        if ( option != null ) {
                            option.quantity += item.quantity;
                            option.price = item.price;
                        }

                        else {
                            CartItemOption cartItemOption = new() {
                                OptionName = productOption.OptionName,
                                price = productOption.Price,
                                quantity = item.quantity,
                                productOptionId = item.productOptionId,
                                CartItemId = cartItem.CartItemId,
                            };
                            cartItem.CartItemOptions.Add(cartItemOption);
                        }
                        cart.TotalAmount += item.quantity * item.price;
                    }
                }
                // neu chua co san pham trong gio hang thi them moi
                else {
                    CartItems items = new() {
                        Price = addItemCartDTO.price,
                        ProductId = addItemCartDTO.productid,
                        Quantity = addItemCartDTO.quantity,
                        CartId = cart.CartId,
                    };
                    foreach ( var item in addItemCartDTO.cartItemOptions ) {
                        var productOption = await productOptionRepo.GetById(item.productOptionId);
                        if ( productOption == null ) {
                            return ApiResponse<bool>.FailResponse("ProductOption not found");
                        }
                        

                        CartItemOption cartItemOption = new() {
                            OptionName = productOption.OptionName,
                            price = productOption.Price,
                            quantity = item.quantity,
                            productOptionId = item.productOptionId,
                            CartItems = items
                        };
                        items.CartItemOptions.Add(cartItemOption);
                        cart.TotalAmount += item.quantity * item.price;
                    }
                    cart.TotalQuantity += 1;
                    cart.TotalAmount += addItemCartDTO.quantity * addItemCartDTO.price;
                    cart.CartItems.Add(items);
                }
                
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true,"Update Thành Công." );
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }
        }
    }
}
