using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class ProductRepo(DataDbConText _context) {
        public async Task<bool> IsProductExists(int productId) {
            return await _context.products.AnyAsync(p => p.ProductId == productId);
        }

        public async Task<bool> IsProductExistsByName(string productName) {
            return await _context.products.AnyAsync(p => p.ProductName == productName);
        }
        public async Task AddProduct(Products product) {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task<Products?> GetByProductId(int productId) {
            return await _context.products.FindAsync(productId);
        }
        public async Task<Products?> GetProductById(int productId) {
            return await _context.products
                .Include(p => p.images)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Products?> GetProductById2(int productId) {
            return await _context.products
                .Include(p => p.Category)
                .Include(p => p.images)
                .Include(p => p.recipes)
                    .ThenInclude(s => s.Ingredient)
                .Include(p => p.productOptions)
                .Include(p => p.productReviews)
                    .ThenInclude(pr => pr.Customers)
                .FirstOrDefaultAsync(p => p.ProductId == productId && p.IsActive == true);
        }
        public async Task<Products?> GetProductByIdForUpdateIngredient(int productId) {
            return await _context.products
                .Include(p => p.recipes)
                    .ThenInclude(s => s.Ingredient)
                .Include(p => p.productOptions)
                    .ThenInclude(s => s.Ingredient)
                .FirstOrDefaultAsync(p => p.ProductId == productId && p.IsActive == true);
        }
        public async Task<List<Products>> GetAllProducts() {
            return await _context.products
                .Include(p => p.images)
                .Include(p => p.Category)
                .Where(s => s.IsActive == true)
                .ToListAsync();
        }
        public async Task<Products?> IsProductExistsByNameAndId(string productName, int id) {
            return await _context.products.FirstOrDefaultAsync(p => p.ProductName == productName && p.ProductId != id);
        }
        public async Task ProductAddOption(ProductOptions productOption) {
            await _context.productOptions.AddAsync(productOption);

        }
        public async Task ProductAddRecipe(Recipes recipe) {
            await _context.recipes.AddAsync(recipe);


        }
        public async Task ProductAddImage(Images image) {
            await _context.images.AddAsync(image);
        }
        public async Task<List<Products>> GetListProductTopSelling() {
            return await _context.products
                .Include(p => p.images)
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.SoldCount)
                .Take(12)
                .ToListAsync();
        }
        public async Task<List<Products>> GetListProductNews() {
            return await _context.products
                .Where(p => p.IsActive == true)
                .Include(p => p.images)
                .OrderByDescending(p => p.Create_At)
                .Take(12)
                .ToListAsync();
        }
        public async Task<List<Products>> GetProductByCategoryIdAndProductId(int categoryId,int productid) {
            return await _context.products
                .Include(p => p.images)
                .Where(s => s.CategoryId == categoryId && s.IsActive == true && s.ProductId != productid)
                .Take(12)
                .ToListAsync();
        }
        public async Task<List<Products>> GetProductByCategoryId(int categoryId) {
            return await _context.products
                .Include(p => p.images)
                .Where(s => s.CategoryId == categoryId && s.IsActive == true )
                .Take(12)
                .ToListAsync();
        }
        public void UpdateProduct(Products products) {
            _context.products.Update(products);
        }
    }
}
