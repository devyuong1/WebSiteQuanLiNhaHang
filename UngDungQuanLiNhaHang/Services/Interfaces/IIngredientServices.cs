using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IIngredientServices {
        Task<ApiResponse<bool>> AddIngredient(IngredientDTO item);
        Task<ApiResponse<bool>> UpdateIngredient(IngredientDTO ingredientDTO);

        Task<ApiResponse<bool>> DisableIngredient(int ingredientId);
        Task<ApiResponse<PageResponse<IngredientResponse>>> GetAllIngredients(int page = 1);
        Task<ApiResponse<IngredientResponse>> GetIngredientById(int ingredientId);
        Task<ApiResponse<List<ListIngredientResponse>>> GetListIngredient();
        Task  UpdateStockIngredinet(int invoiceId);
    }
}
