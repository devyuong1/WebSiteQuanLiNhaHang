using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface SupplierServices {
        public Task<ApiResponse<bool>> AddSupplier(SupplierDTO supplierDTO);
        public Task<ApiResponse<bool>> UpdateSupplier(SupplierDTO supplierDTO);
        public Task<ApiResponse<bool>> DisableSupplier(int supplierId,int isActive);
        public Task<ApiResponse<List<SupplierResponse>>> GetAllSuppliers();
        public Task<ApiResponse<SupplierResponse>> GetSupplierById(int supplierId);
    }
}
