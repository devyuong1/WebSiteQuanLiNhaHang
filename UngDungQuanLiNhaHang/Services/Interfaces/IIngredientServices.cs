using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IIngredientServices {
        public Task<ApiResponse<bool>> AddIngredient(IngredientDTO item);
        public Task<ApiResponse<bool>> UpdateIngredient(IngredientDTO ingredientDTO);

        public Task<ApiResponse<bool>> DisableIngredient(int ingredientId);
        public Task<ApiResponse<IEnumerable<IngredientResponse>>> GetAllIngredients();
        public Task<ApiResponse<IngredientResponse>> GetIngredientById(int ingredientId);
    }
}
