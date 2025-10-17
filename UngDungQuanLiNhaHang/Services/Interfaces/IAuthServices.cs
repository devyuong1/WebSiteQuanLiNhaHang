using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IAuthServices {
        public Task<ApiResponse<UserDetails>> Login(LoginDTO customer);
        public Task<ApiResponse<bool>> Register(CustomerDTO customer);
        public  Task<ApiResponse<CustomerResponse>> RefreshToken(TokenRequestDTO item);
        public  Task<ApiResponse<UserDetails>> RefreshTokenEmployee(TokenRequestDTO item);
        public Task<ApiResponse<UserDetails>> LoginEmployee(LoginDTO employee);

    }
}
