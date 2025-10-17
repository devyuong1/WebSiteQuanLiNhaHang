using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IProductService {
        Task<ApiResponse<int>> AddProduct(ProductDTO productDTO);
         Task<ApiResponse<bool>> AddImgProduct(int productId, List<ImgProductDTO> imgProductDTO);
         Task<ApiResponse<bool>> UpdateImgProduct(int productId, List<ImgProductDTO> imgProductDTO);
         Task<ApiResponse<int>> UpdateProduct(UpdateProductDTO productDTO);
         Task<ApiResponse<bool>> ActiveProduct(int productId);
         Task<ApiResponse<PageResponse<ProductResponse>>> GetAllProducts(ProductPageDTO productPageDTO);
         Task<ApiResponse<ProductDetailResponse>> GetProductById(int product);
        Task<ApiResponse<List<ProductResponse>>> GetListProductTopSelling();

        Task<ApiResponse<List<ProductResponse>>> GetListProductNews();
        Task<ApiResponse<List<ProductResponse>>> GetProductByCategoryid(int categoryId);

    }
}
