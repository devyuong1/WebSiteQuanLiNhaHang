using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface EmployeeServices {
        public Task<ApiResponse<bool>> AddEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> DisableEmployee(int employeeId,int isActive);
        public Task<ApiResponse<List<EmployeeDTO>>> GetAllEmployees();  
        public Task<ApiResponse<EmployeeDTO>> GetEmployeeById(int employeeId);
    }
}
