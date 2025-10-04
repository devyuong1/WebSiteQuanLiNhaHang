using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IAuthServices {
        public Task<ApiResponse<CustomerResponse>> Login(LoginDTO customer);
        public Task<ApiResponse<bool>> Register(CustomerDTO customer);
    }
}
