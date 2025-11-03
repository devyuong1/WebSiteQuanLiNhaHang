using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IEmployeeServices {
        Task<ApiResponse<bool>> AddEmployee(EmployeeDTO employeeDTO);
        Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<ApiResponse<bool>> DisableEmployee(int employeeId);
        Task<ApiResponse<PageResponse<EmployeeResponse>>> GetAllEmployees(int page = 1);  
        Task<ApiResponse<EmployeeResponse>> GetEmployeeById(int employeeId);
        Task<ApiResponse<List<RoleResponse>>> GetRoles();
    }
}
