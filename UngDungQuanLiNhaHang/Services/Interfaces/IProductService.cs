using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IProductService {
        public Task<ApiResponse<int>> AddProduct(ProductDTO productDTO);
        public Task<ApiResponse<bool>> AddImgProduct(int productId, List<ImgProductDTO> imgProductDTO);
        public Task<ApiResponse<bool>> UpdateImgProduct(int productId, List<ImgProductDTO> imgProductDTO);
        public Task<ApiResponse<int>> UpdateProduct(UpdateProductDTO productDTO);
        public Task<ApiResponse<bool>> ActiveProduct(int productId);
        public Task<ApiResponse<PageResponse<ProductResponse>>> GetAllProducts(ProductPageDTO productPageDTO);
        public Task<ApiResponse<ProductResponse>> GetProductById(int product);
    }
}
