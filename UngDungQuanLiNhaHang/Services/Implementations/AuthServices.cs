using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;
using BCrypt.Net;
namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class AuthServices(CustomerRepo customerRepo) : IAuthServices {
        public async Task<ApiResponse<CustomerResponse>> Login(LoginDTO customer) {
            var user = await customerRepo.GetCustomerByEmail(customer.Email);
            if (user == null ) {
                return ApiResponse<CustomerResponse>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }
            if ( !BCrypt.Net.BCrypt.Verify(customer.Password,user.Password ) ){
                return ApiResponse<CustomerResponse>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }


            


            return ApiResponse<CustomerResponse>.FailResponse("Đăng nhập thành công!!!");
        }

        public Task<ApiResponse<bool>> Register(CustomerDTO customer) {
            throw new NotImplementedException();
        }
    }
}
