using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class CartRepo(DataDbConText _context) {
        public async Task<Carts?> GetCartByCustomerId(int customerId) {
            return await _context.carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Products)
                .FirstOrDefaultAsync(c => c.customerId == customerId);
        }
        public void UpdateCart(Carts cart) {
            _context.carts.Update(cart);
        }   
        public async Task AddCart(Carts cart) {
            await _context.carts.AddAsync(cart);
        }
    }
}
