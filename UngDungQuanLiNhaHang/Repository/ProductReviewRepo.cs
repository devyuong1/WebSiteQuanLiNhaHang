using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class ProductReviewRepo(DataDbConText _context) {
        public async Task CreateProductReview(ProductReviews productReviews) {
            await _context.productReviews.AddAsync(productReviews);

        }
        public async Task<ProductReviews?> GetProductReviewByProductIdAndInvoiceId(int invoiceId,int productid) {
            return await _context.productReviews.FirstOrDefaultAsync(i => i.InvoiceId == invoiceId && i.ProductId == productid);
        }
        public async Task<ProductReviews?> GetProductReviewById(int productReviewId) {
            return await _context.productReviews.FindAsync(productReviewId);
        }
        public async Task<ProductReviews?> GetProductReviewByCustomerIdAndReviewId(int customerId, int productReviewId) {
            return await _context.productReviews
                .FirstOrDefaultAsync(pr => pr.ProductReviewId == productReviewId && pr.CustomerId == customerId);
        }
        public void DeleteProductReview(ProductReviews productReviews) {
            _context.productReviews.Remove(productReviews);
        }

        public void UpdateProductReview(ProductReviews productReviews) {
            _context.productReviews.Update(productReviews);
        }
    }
}
