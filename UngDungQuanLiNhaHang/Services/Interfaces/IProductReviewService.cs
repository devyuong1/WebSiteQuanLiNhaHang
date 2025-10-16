using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IProductReviewService {
        // tạo đánh giá sản phẩm
        Task<ApiResponse<bool>> CreateProductReview(int customerId, ProductReviewDTO productReviewDTO);
        // xóa đánh giá của khách hàng
        Task<ApiResponse<bool>> DeleteProductReview(int customerId, int productReviewId);
        // cập nhật đánh giá của khách hàng
        Task<ApiResponse<bool>> UpdateProductReview(int customerId, ProductReviewDTO productReviewDTO);
    }
}
