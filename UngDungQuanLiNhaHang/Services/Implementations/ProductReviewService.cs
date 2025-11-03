using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class ProductReviewService(
        ProductReviewRepo repo,
        InvoiceRepo invoiceRepo,
        ProductRepo productRepo,
        TransactionRepo transactionRepo
        ) : IProductReviewService {
        // tạo đánh giá sản phẩm
        public async Task<ApiResponse<bool>> CreateProductReview(int customerId, ProductReviewDTO productReviewDTO) {
            var invoice = await invoiceRepo.GetByCustomerIdAndInvoiceId(customerId, productReviewDTO.invoiceId);
            if ( invoice == null ) {
                return ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ");

            }
            var productReview = await repo.GetProductReviewByProductIdAndInvoiceId(productReviewDTO.invoiceId, productReviewDTO.productId);
            if (productReview != null) {
                return ApiResponse<bool>.FailResponse("Sản phẩm đã được đánh giá rồi.");
            }
            var productInInvoice = invoice.invoiceItems.FirstOrDefault(ii => ii.ProductId == productReviewDTO.productId);
            if ( productInInvoice == null ) {
                return ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ");
            }
            var product = await productRepo.GetByProductId(productReviewDTO.productId);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Sản phẩm không tồn tại");
            }


            ProductReviews productReviews = new ProductReviews {
                Rating = productReviewDTO.rating,
                Comment = productReviewDTO.comment,
                Create_At = DateTime.Now,
                CustomerId = customerId,
                InvoiceId = productReviewDTO.invoiceId,
                ProductId = productReviewDTO.productId
            };

            try {
                await transactionRepo.BeginTransactionAsync();
                await repo.CreateProductReview(productReviews);
                product.AverageRating = ( ( product.AverageRating * product.TotalReviews ) + productReviewDTO.rating ) / ( product.TotalReviews + 1 );
                product.TotalReviews += 1;

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Đánh giá sản phẩm thành công");

            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Đánh giá sản phẩm thất bại" + ex.ToString());

            }
        }

        public async Task<ApiResponse<bool>> DeleteProductReview(int customerId, int productReviewId) {
            var productReview = await repo.GetProductReviewByCustomerIdAndReviewId(customerId, productReviewId);
            if ( productReview == null ) {
                return ApiResponse<bool>.FailResponse("Đánh giá không tồn tại");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                repo.DeleteProductReview(productReview);
                var product = await productRepo.GetByProductId(productReview.ProductId);
                if ( product != null && product.TotalReviews > 1 ) {
                    product.AverageRating = ( ( product.AverageRating * product.TotalReviews ) - productReview.Rating ) / ( product.TotalReviews - 1 );
                    product.TotalReviews -= 1;
                }
                else if ( product != null && product.TotalReviews == 1 ) {
                    product.AverageRating = 0;
                    product.TotalReviews = 0;
                }
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Xóa đánh giá thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Xóa đánh giá thất bại" + ex.ToString());
            }
        }

        public async Task<ApiResponse<ProductReviewResponse>> GetProductReviewByInvoiIdAndProductId(int invoiceId, int productId) {
            var result = await repo.GetProductReviewByProductIdAndInvoiceId(invoiceId, productId);
            if (result == null ) {
                return ApiResponse<ProductReviewResponse>.FailResponse("Chưa có đánh giá.");
            }
            ProductReviewResponse respon = new() {
                rating = result.Rating,
                productReviewId = result.ProductReviewId,
                comment = result.Comment,
                create_At = result.Create_At,
                userName = "",
            };
            return ApiResponse<ProductReviewResponse>.SuccessResponse(respon);
           
        }

        public async Task<ApiResponse<bool>> UpdateProductReview(int customerId, ProductReviewDTO productReviewDTO) {
            var productReview = await repo.GetProductReviewByCustomerIdAndReviewId(customerId, productReviewDTO.productReviewId);
            if ( productReview == null ) {
                return ApiResponse<bool>.FailResponse("Đánh giá không tồn tại");
            }
            var product = await productRepo.GetByProductId(productReview.ProductId);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Sản phẩm không tồn tại");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                // cập nhật lại điểm trung bình
                product.AverageRating = ( ( product.AverageRating * product.TotalReviews ) - productReview.Rating + productReviewDTO.rating ) / product.TotalReviews;
                productReview.Rating = productReviewDTO.rating;
                productReview.Comment = productReviewDTO.comment;

                repo.UpdateProductReview(productReview);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật đánh giá thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Cập nhật đánh giá thất bại" + ex.ToString());
            }
        } 
    }
}
