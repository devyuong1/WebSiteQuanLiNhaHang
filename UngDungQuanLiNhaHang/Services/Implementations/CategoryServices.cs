using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CategoryServiceṣ̣̣̣̣̣(CategoryRepo categoryRepo, TransactionRepo transactionRepo) : ICategoryServices {
        public async Task<ApiResponse<bool>> AddCategory(CategoryDTO categoryDTO) {
            var result = await categoryRepo.GetByName(categoryDTO.categoryName);
            if ( result != null )
                return ApiResponse<bool>.FailResponse("Danh mục đã tồn tại.");
            Categorys categorys = new Categorys {
                CategoryName = categoryDTO.categoryName,
                IsActive = true
            };
            try {
                await transactionRepo.BeginTransactionAsync();
                await categoryRepo.AddCategory(categorys);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Thêm danh mục thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Thêm danh mục thất bại. Lỗi: " + ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> DisableCategory(int categoryId) {
            var result = await categoryRepo.GetCategoryById(categoryId);
            if ( result == null )
                return ApiResponse<bool>.FailResponse("Danh mục không tồn tại.");

            try {
                await transactionRepo.BeginTransactionAsync();
                result.IsActive = !result.IsActive;


                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật danh mục thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Cập nhật danh mục thất bại. Lỗi: " + ex.Message);
            }
        }

        

        public async Task<ApiResponse<PageResponse<CategoryResponse>>> GetAllCategories(int page = 1) {
            int pageSize = 12;

            var result = await categoryRepo.GetAllCategories();
            if ( result == null || !result.Any() )
                return ApiResponse<PageResponse<CategoryResponse>>.FailResponse("Không có danh mục nào.");
            var categoryDTOs = result.Select(c => new CategoryResponse {
                categoryId = c.CategoryId,
                categoryName = c.CategoryName,
                isActive = c.IsActive
            }).ToList();
            var pagedCategoryDTOs = categoryDTOs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var totalItems = categoryDTOs.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var pageResponse = new PageResponse<CategoryResponse> {
                totalItems = totalItems,
                totalPages = totalPages,
                pageSize = pageSize,
                page = page,
                list = pagedCategoryDTOs
            };
            return ApiResponse<PageResponse<CategoryResponse>>.SuccessResponse(pageResponse, "Lấy danh mục thành công.");
        }

        public async Task<ApiResponse<CategoryResponse>> GetCategoryById(int categoryId) {
            var result = await categoryRepo.GetCategoryById(categoryId);
            if ( result == null )
                return ApiResponse<CategoryResponse>.FailResponse("Danh mục không tồn tại.");
            var categoryDTO = new CategoryResponse {
                categoryId = result.CategoryId,
                categoryName = result.CategoryName,
                isActive = result.IsActive
            };
            return ApiResponse<CategoryResponse>.SuccessResponse(categoryDTO, "Lấy danh mục thành công.");
        }

        public async Task<ApiResponse<bool>> UpdateCategory(CategoryDTO categoryDTO) {
            var result = await categoryRepo.GetCategoryById(categoryDTO.categoryId);
            if ( result == null )
                return ApiResponse<bool>.FailResponse("Danh mục không tồn tại.");

            try {
                await transactionRepo.BeginTransactionAsync();
                result.CategoryName = categoryDTO.categoryName;
                result.IsActive = categoryDTO.isActive;
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật danh mục thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Cập nhật danh mục thất bại. Lỗi: " + ex.Message);
            }
        }
    }
}
