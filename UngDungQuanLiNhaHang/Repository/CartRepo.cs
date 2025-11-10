using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class CartRepo(DataDbConText _context) {
        public async Task<Carts?> GetCartByCustomerId(int customerId) {
            return await _context.carts
                
                .Include(s => s.Customers)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Products)
                        .ThenInclude(p => p.images)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.CartItemOptions)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public async Task<Carts?> GetCart(int customerId) {
            return await _context.carts
                .Include(c => c.CartItems)
                    .ThenInclude( s => s.CartItemOptions)
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public void UpdateCart(Carts cart) {
            _context.carts.Update(cart);
        }   

        public async Task AddCart(Carts cart) {
            await _context.carts.AddAsync(cart);
        }

        public async Task<CartItemOption?> GetCartItemOption(int cartItemId,int cartOptionId) {
            return await _context.cartItemOptions.FirstOrDefaultAsync(s => s.Id == cartOptionId && s.CartItemId == cartItemId);
        }
        public void deleteItem(CartItems item) {
            _context.cartItems.Remove(item);
        }
        public async Task<CartItems?> GetCartItemById(int id) {
            return await _context.cartItems.FirstOrDefaultAsync(s => s.CartItemId == id);
        }
        public async Task<CartItems?> GetCartItemByProductIdAndCartId(int cartID, int productId) {
            return await _context.cartItems.FirstOrDefaultAsync(s => s.CartId == cartID && s.ProductId == productId);
        }
        public void DeleteCartItems(List<CartItems> cartItems) {
            _context.cartItems.RemoveRange(cartItems);
        }
        public async Task<Carts?> getCartByCustomerId(int customerId) {
            return await _context.carts.Include(c => c.CartItems).FirstOrDefaultAsync(s => s.CustomerId == customerId);
        }
    }
}
