using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class CategoryRepo(DataDbConText _context) {
        public async Task<IEnumerable<Categorys>> GetAllCategories() {
            return await _context.categories.ToListAsync();
        }
        public async Task<Categorys?> GetCategoryById(int id) {
            return await _context.categories.FindAsync(id);
        }
        public async Task AddCategory(Categorys category) {
            await _context.categories.AddAsync(category);

        }
        public void UpdateCategory(Categorys category) {
            _context.Entry(category).State = EntityState.Modified;

        }
        public async Task<Categorys?> GetByName(string name) {
            return await _context.categories.FirstOrDefaultAsync(c => c.CategoryName == name);
        }
    }
}
