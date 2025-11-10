
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Security;
using UngDungQuanLiNhaHang.Services.Interfaces;
using Hangfire;
namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class AuthServices(CustomerRepo customerRepo,
        JWT jwt,TransactionRepo transactionRepo,
        CartRepo cartRepo,
        EmployeeRepo employeeRepo,
        RefreshTokenRepo refreshTokenRepo
        
        ) : IAuthServices {
        public async Task<ApiResponse<UserDetails>> Login(LoginDTO customer) {
            var user = await customerRepo.GetCustomerByEmail(customer.Email);
            if (user == null ) {
                return ApiResponse<UserDetails>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }
            if (!BCrypt.Net.BCrypt.Verify(customer.Password,user.Password) ){
                return ApiResponse<UserDetails>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }

            var token = jwt.GenerateJWT(user.FullName, user.CustomerId, user.Role!.RoleName);
            
            var response = new UserDetails {
                userId = user.CustomerId,
                fullName = user.FullName,
                email = user.Email,
                access_token = token,
                role = user.Role?.RoleName ?? "Customer",
                refresh_token = user.refreshTokens!.Last().Token
            };
            
            if ( user.refreshTokens == null || user.refreshTokens.Last().ExpiresAt < DateTime.UtcNow || user.refreshTokens.Last().IsUsed  ) {
                var refreshToken = jwt.GenerateRefreshToken(user.FullName,user.CustomerId);
                RefreshTokens rfToken = new RefreshTokens {
                    Token = refreshToken,
                    JwtId = "1234567890",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false,
                    customerId = user.CustomerId
                };
                user.refreshTokens!.Add(rfToken);
                
                customerRepo.UpdateCustomer(user);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                response.refresh_token = refreshToken;
            }
            
            return ApiResponse<UserDetails>.SuccessResponse(response);
        }

        public async Task<ApiResponse<bool>> Register(CustomerDTO customer) {
            var user = await customerRepo.GetCustomerByEmail(customer.Email);
            if ( user != null ) {
                return ApiResponse<bool>.FailResponse("Email đã tồn tại.");
            }
            user = await customerRepo.GetCustomerByPhonel(customer.Phone);
            if ( user != null ) {
                return ApiResponse<bool>.FailResponse("Số điện thoại đã tồn tại.");
            }
            if (customer.Password != customer.PasswordVerify) {
                return ApiResponse<bool>.FailResponse("Mật khẩu không khớp.");
            }
            var refreshToken = jwt.GenerateRefreshToken(customer.FullName, 0);
            try {
                RefreshTokens rfToken = new RefreshTokens {
                    Token = refreshToken,
                    JwtId = "1234567890",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false,
                };
                
                Customers newCustomer = new Customers {
                    FullName = customer.FullName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Password = BCrypt.Net.BCrypt.HashPassword(customer.Password),
                    RoleId = 4,
                   

                };
                newCustomer.refreshTokens.Add(rfToken);
                await customerRepo.AddCustomer(newCustomer);

                await transactionRepo.CompleteAsync();


                Carts carts = new() {
                    TotalAmount = 0,
                    TotalQuantity = 0,
                    CustomerId = newCustomer.CustomerId
                };
                await cartRepo.AddCart(carts);
                await transactionRepo.CompleteAsync();
               
                
                await transactionRepo.CommitAsync();
                string subject = "🎉 Chúc mừng! Tài khoản của bạn đã được tạo thành công";

                string body = $@"
                    <div style=""font-family:Arial, sans-serif;padding:20px;border:1px solid #eee;"">
                        <h2 style=""color:#007bff;"">Đăng ký tài khoản thành công</h2>
                        <p>Xin chào <b>{customer.FullName}</b>,</p>

                        <p>Cảm ơn bạn đã đăng ký tài khoản tại hệ thống của chúng tôi.</p>
                        <p>Bây giờ bạn đã có thể đăng nhập và sử dụng đầy đủ các chức năng.</p>

                        <hr/>
                        <p style=""color:#888;font-size:12px;margin-top:20px;"">Đây là email tự động, vui lòng không phản hồi.</p>
                    </div>";
                BackgroundJob.Schedule<IEmailService>(emailService => emailService.SendEmailAsync(newCustomer.Email, subject, body), TimeSpan.FromSeconds(60));
                
                return ApiResponse<bool>.SuccessResponse(true,"Đăng ký tài khoản thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }

        }

        public async Task<ApiResponse<CustomerResponse>> RefreshToken(TokenRequestDTO item) {
          
            var storedRefreshToken = await refreshTokenRepo.GetCustomerByRf(item.refresh_token);
            if ( storedRefreshToken == null || storedRefreshToken.Customers == null) {
                return ApiResponse<CustomerResponse>.FailResponse("Refresh token không tồn tại.");
            }
            if (  storedRefreshToken.IsUsed ) {
                return ApiResponse<CustomerResponse>.FailResponse("Refresh token đã được sử dụng.");
            }
            if ( storedRefreshToken.IsRevoked ) {
                return ApiResponse<CustomerResponse>.FailResponse("Refresh token đã bị thu hồi.");
            }
            if ( storedRefreshToken.ExpiresAt < DateTime.UtcNow ) {
                return ApiResponse<CustomerResponse>.FailResponse("Refresh token đã hết hạn.");
            }
            var user = storedRefreshToken.Customers;
            try {
                await transactionRepo.BeginTransactionAsync();
                

                
                var newJwtToken = jwt.GenerateJWT(user.FullName, user.CustomerId, user.Role!.RoleName);
                var newRefreshToken = jwt.GenerateRefreshToken(user.FullName,user.CustomerId);
                RefreshTokens rfToken = new RefreshTokens {
                    customerId = user.CustomerId,
                    Token = newRefreshToken,
                    JwtId = "1234567890",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false,
                    ReplacedByToken = item.refresh_token
                };
                storedRefreshToken.IsUsed = true;

                user.refreshTokens!.Add(rfToken);
                customerRepo.UpdateCustomer(user);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                var response = new CustomerResponse {
                    customerId = user.CustomerId,
                    fullName = user.FullName,
                    email = user.Email,
                    access_token = newJwtToken,
                    refresh_token = newRefreshToken
                };
                return ApiResponse<CustomerResponse>.SuccessResponse(response);
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<CustomerResponse>.FailResponse(ex.Message);
            }
        }

        public async Task<ApiResponse<UserDetails>> RefreshTokenEmployee(TokenRequestDTO item) {
            var storedRefreshToken = await refreshTokenRepo.GetEmployeeByRf(item.refresh_token);
            if ( storedRefreshToken == null || storedRefreshToken.Employees == null ) {
                return ApiResponse<UserDetails>.FailResponse("Refresh token không tồn tại.");
            }
            if ( storedRefreshToken.IsUsed ) {
                return ApiResponse<UserDetails>.FailResponse("Refresh token đã được sử dụng.");
            }
            if ( storedRefreshToken.IsRevoked ) {
                return ApiResponse<UserDetails>.FailResponse("Refresh token đã bị thu hồi.");
            }
            if ( storedRefreshToken.ExpiresAt < DateTime.UtcNow ) {
                return ApiResponse<UserDetails>.FailResponse("Refresh token đã hết hạn.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();

                var employee = storedRefreshToken.Employees;

                var newJwtToken = jwt.GenerateJWT(employee.Fullname, employee.EmployeeId, employee.Role!.RoleName);
                var newRefreshToken = jwt.GenerateRefreshToken(employee.Fullname,employee.EmployeeId);
                RefreshTokens rfToken = new RefreshTokens {
                   employeeId = employee.EmployeeId,
                    Token = newRefreshToken,
                    JwtId = "1234567890",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false,
                    ReplacedByToken = item.refresh_token
                };
                storedRefreshToken.IsUsed = true;

                employee.RefreshTokens!.Add(rfToken);
                employeeRepo.UpdateEmployee(employee);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                var response = new UserDetails {
                    userId = employee.EmployeeId,
                    fullName = employee.Fullname,
                    email = employee.Email,
                    access_token = newJwtToken,
                    refresh_token = newRefreshToken
                };
                return ApiResponse<UserDetails>.SuccessResponse(response);
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<UserDetails>.FailResponse(ex.Message);
            }
        }

        public async Task<ApiResponse<UserDetails>> LoginEmployee(LoginDTO employee) {
            var user = await employeeRepo.GetEmployeeByEmail(employee.Email);
            if ( user == null ) {
                return ApiResponse<UserDetails>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }
            if ( !BCrypt.Net.BCrypt.Verify(employee.Password,user.Password )) {
                return ApiResponse<UserDetails>.FailResponse("Sai tài khoản hoặc mật khẩu!!!");
            }

            var token = jwt.GenerateJWT(user.Fullname, user.EmployeeId, user.Role!.RoleName);

            var response = new UserDetails {
                userId = user.EmployeeId,
                fullName = user.Fullname,
                email = user.Email,
                access_token = token,
                role = user.Role?.RoleName ?? "Employee",
                refresh_token = user.RefreshTokens.Any() ? user.RefreshTokens.Last().Token : null
            };

            var rfToken1 = user.RefreshTokens.Last();
            if (rfToken1.Token == null || rfToken1.ExpiresAt < DateTime.Now || rfToken1.IsUsed) {
                var refreshToken = jwt.GenerateRefreshToken(user.Fullname, user.EmployeeId);
                RefreshTokens rfToken = new RefreshTokens {
                    Token = refreshToken,
                    JwtId = "1234567890",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false,
                    employeeId = user.EmployeeId
                };
                user.RefreshTokens!.Add(rfToken);

                employeeRepo.UpdateEmployee(user);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                response.refresh_token = refreshToken;
            }
           

            return ApiResponse<UserDetails>.SuccessResponse(response);
        }
    }
}
