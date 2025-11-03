using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ISupplierServices {
        Task<ApiResponse<bool>> AddSupplier(SupplierDTO supplierDTO);
        Task<ApiResponse<bool>> UpdateSupplier(SupplierDTO supplierDTO);
        
        Task<ApiResponse<PageResponse<SupplierResponse>>> GetAllSuppliers(int page = 1);
        Task<ApiResponse<SupplierResponse>> GetSupplierById(int supplierId);
        Task<ApiResponse<List<ListSupplierResponse>>> GetListSuppliers();

    }
}
