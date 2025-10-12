using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ISupplierServices {
        public Task<ApiResponse<bool>> AddSupplier(SupplierDTO supplierDTO);
        public Task<ApiResponse<bool>> UpdateSupplier(SupplierDTO supplierDTO);
        
        public Task<ApiResponse<PageResponse<SupplierResponse>>> GetAllSuppliers(int page = 1);
        public Task<ApiResponse<SupplierResponse>> GetSupplierById(int supplierId);
    }
}
