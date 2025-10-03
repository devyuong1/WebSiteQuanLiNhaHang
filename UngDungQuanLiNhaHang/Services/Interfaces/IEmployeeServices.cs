using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IEmployeeServices {
        public Task<ApiResponse<bool>> AddEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO);
        public Task<ApiResponse<bool>> DisableEmployee(int employeeId);
        public Task<ApiResponse<IEnumerable<EmployeeResponse>>> GetAllEmployees();  
        public Task<ApiResponse<EmployeeResponse>> GetEmployeeById(int employeeId);
    }
}
