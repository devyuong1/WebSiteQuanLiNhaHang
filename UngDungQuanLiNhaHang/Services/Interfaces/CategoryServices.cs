using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface CategoryServices {
        public Task<ApiResponse<bool>> AddCategory(CategoryDTO categoryDTO);
        public Task<ApiResponse<bool>> UpdateCategory(CategoryDTO categoryDTO);
        public Task<ApiResponse<bool>> DisableCategory(int categoryId,int isActive);
        public Task<ApiResponse<List<CategoryDTO>>> GetAllCategories();
        public Task<ApiResponse<CategoryDTO>> GetCategoryById(int categoryId);
    }
}
