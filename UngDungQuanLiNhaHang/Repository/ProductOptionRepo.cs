using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class ProductOptionRepo(DataDbConText _context) {
        public async Task<ProductOptions?> GetById(int id) {
            return await _context.productOptions.FindAsync(id);
        }
    }
}
