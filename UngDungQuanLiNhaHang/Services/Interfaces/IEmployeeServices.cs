using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IEmployeeServices {
        public Task<ApiResponse<bool>> AddEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> DisableEmployee(int employeeId);
        public Task<ApiResponse<PageResponse<EmployeeResponse>>> GetAllEmployees(int page = 1);  
        public Task<ApiResponse<EmployeeResponse>> GetEmployeeById(int employeeId);
    }
}
