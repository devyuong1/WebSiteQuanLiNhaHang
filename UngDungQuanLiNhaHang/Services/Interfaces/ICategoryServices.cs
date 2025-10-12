using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ICategoryServices {
        public Task<ApiResponse<bool>> AddCategory(CategoryDTO categoryDTO);
        public Task<ApiResponse<bool>> UpdateCategory(CategoryDTO categoryDTO);
        public Task<ApiResponse<bool>> DisableCategory(int categoryId);
        public Task<ApiResponse<PageResponse<CategoryResponse>>> GetAllCategories(int page = 1);
        public Task<ApiResponse<CategoryResponse>> GetCategoryById(int categoryId);
    }
}
