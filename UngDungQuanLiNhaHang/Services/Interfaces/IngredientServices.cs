using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IngredientServices {
        public Task<ApiResponse<bool>> AddIngredient(IngredientDTO item);
        public Task<ApiResponse<bool>> UpdateIngredient(IngredientDTO ingredientDTO);

        public Task<ApiResponse<bool>> DisableIngredient(int ingredientId,int isActive);
        public Task<ApiResponse<List<IngredientDTO>>> GetAllIngredients();
        public Task<ApiResponse<IngredientDTO>> GetIngredientById(int ingredientId);
    }
}
