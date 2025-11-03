using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IAuthServices {
         Task<ApiResponse<UserDetails>> Login(LoginDTO customer);
         Task<ApiResponse<bool>> Register(CustomerDTO customer);
          Task<ApiResponse<CustomerResponse>> RefreshToken(TokenRequestDTO item);
          Task<ApiResponse<UserDetails>> RefreshTokenEmployee(TokenRequestDTO item);
         Task<ApiResponse<UserDetails>> LoginEmployee(LoginDTO employee);

    }
}
