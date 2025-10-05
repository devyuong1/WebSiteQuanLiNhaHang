using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;

namespace UngDungQuanLiNhaHang.Repository {
    public class ProductRepo(DataDbConText _context) {
        public async Task<bool> IsProductExists(int productId) {
            return await _context.products.AnyAsync(p => p.ProductId == productId);
        }
    }
}
