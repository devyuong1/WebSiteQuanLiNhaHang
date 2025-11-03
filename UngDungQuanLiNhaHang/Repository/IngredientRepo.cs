using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class IngredientRepo(DataDbConText _context) {
        public async Task AddIngredient(Ingredient item) {
            await _context.ingredients.AddAsync(item);
        }
        public async Task<Ingredient?> GetIngredientById(int ingredientId) {
            return await _context.ingredients.FindAsync(ingredientId);
        }
        public void UpdateIngredient(Ingredient item) {
            _context.ingredients.Update(item);
        }
        public async Task<IEnumerable<Ingredient>> GetAllIngredients() {
            return await _context.ingredients.ToListAsync();
        }
        public async Task<Ingredient?> GetIngredientByName(string name) {
            return await _context.ingredients.FirstOrDefaultAsync(i => i.IngredientName == name);
        }
        public async Task<List<Ingredient>> GetListIngredient() {
            return await _context.ingredients.AsNoTracking().ToListAsync();
        }
    }
}
