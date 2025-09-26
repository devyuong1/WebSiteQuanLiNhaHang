using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IAuthServices {
        public Task<ApiResponse<CustomerResponse>> Login(string Email, string password);
        public Task<ApiResponse<bool>> Register(Customers customer);
    }
}
