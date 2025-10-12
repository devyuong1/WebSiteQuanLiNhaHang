using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class IngredientService(IngredientRepo ingredientRepo,TransactionRepo transactionRepo) : IIngredientServices {
        public async Task<ApiResponse<bool>> AddIngredient(IngredientDTO item) {
            if (item.minQuantity < 0 || item.minQuantity > item.quantity) {
                return ApiResponse<bool>.FailResponse("Số lượng tối thiểu không hợp lệ");
            }
            var result = await ingredientRepo.GetIngredientByName(item.ingredientName);
            if ( result != null ) {
                return ApiResponse<bool>.FailResponse("Nguyên liệu đã tồn tại");
            }
            Ingredient ing = new () {
                IngredientName = item.ingredientName,
                Unit = item.unit,
                Quantity = item.quantity,
                Price = item.price,
                MinQuantity = item.minQuantity,
                IsActive = true
            };
            try {
                await transactionRepo.BeginTransactionAsync();
                
                await ingredientRepo.AddIngredient(ing);

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> DisableIngredient(int ingredientId) {
            var ingredient = await ingredientRepo.GetIngredientById(ingredientId);
            if ( ingredient == null ) {
                return ApiResponse<bool>.FailResponse("Nguyên liệu không tồn tại");
            }
            ingredient.IsActive = !ingredient.IsActive;
            try {
                await transactionRepo.BeginTransactionAsync();
                ingredientRepo.UpdateIngredient(ingredient);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }
        }

        public async Task<ApiResponse<PageResponse<IngredientResponse>>> GetAllIngredients(int page =1) {
            int pageSize = 12;
            var ingredients = await ingredientRepo.GetAllIngredients();
            if ( ingredients == null || !ingredients.Any() ) {
                return ApiResponse<PageResponse<IngredientResponse>>.FailResponse("Không có nguyên liệu nào");
            }
            var response = ingredients.Select(i => new IngredientResponse {
                ingredientId = i.IngredientId,
                ingredientName = i.IngredientName,
                price = i.Price,
                unit = i.Unit,
                quantity = i.Quantity,
                minQuantity = i.MinQuantity,
                isActive = i.IsActive
            }).ToList();
            int totalItems = response.Count();
            var pagedResponse = response
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            PageResponse<IngredientResponse> responsePage = new PageResponse<IngredientResponse> {
                page = page,
                pageSize = pageSize,
                totalItems = totalItems,
                totalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                list = pagedResponse
            };
            return ApiResponse<PageResponse<IngredientResponse>>.SuccessResponse(responsePage);
        }

        public async Task<ApiResponse<IngredientResponse>> GetIngredientById(int ingredientId) {
            var ingredients = await ingredientRepo.GetIngredientById(ingredientId);
            if ( ingredients == null  ) {
                return ApiResponse<IngredientResponse>.FailResponse("Không có nguyên liệu nào");
            }
            IngredientResponse response = new() {
                ingredientName = ingredients.IngredientName,
                ingredientId = ingredients.IngredientId,
                unit = ingredients.Unit,
                price = ingredients.Price,
                quantity = ingredients.Quantity,
                minQuantity = ingredients.MinQuantity,
                isActive = ingredients.IsActive
            };
            return ApiResponse<IngredientResponse>.SuccessResponse(response);
        }

        public async Task<ApiResponse<bool>> UpdateIngredient(IngredientDTO ingredientDTO) {
            var ingredient = await ingredientRepo.GetIngredientByName(ingredientDTO.ingredientName); 
            if ( ingredient != null && ingredient.IngredientId != ingredientDTO.ingredientId ) {
                return ApiResponse<bool>.FailResponse("Tên nguyên liệu đã tồn tại");
            }
            
            if ( ingredientDTO.minQuantity < 0 || ingredientDTO.minQuantity > ingredientDTO.quantity) {
                return ApiResponse<bool>.FailResponse("Số lượng tối thiểu không hợp lệ");
            }
            ingredient = await ingredientRepo.GetIngredientById(ingredientDTO.ingredientId);
            if ( ingredient == null ) {
                return ApiResponse<bool>.FailResponse("Nguyên liệu không tồn tại");
            }
            ingredient.IngredientName = ingredientDTO.ingredientName;
            ingredient.Unit = ingredientDTO.unit;
            ingredient.Quantity = ingredientDTO.quantity;
            ingredient.Price = ingredientDTO.price;
            ingredient.MinQuantity = ingredientDTO.minQuantity;
            ingredient.IsActive = ingredientDTO.isActive;
            try {
                await transactionRepo.BeginTransactionAsync();
                ingredientRepo.UpdateIngredient(ingredient);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }
        }
    }
}
