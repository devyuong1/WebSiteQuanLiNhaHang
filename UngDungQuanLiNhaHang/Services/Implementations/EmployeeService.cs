using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class EmployeeService(EmployeeRepo employeeRepo,
        TransactionRepo transactionRepo,
        AddressRepo addressRepo
        ) : IEmployeeServices {
        public async Task<ApiResponse<bool>> AddEmployee(EmployeeDTO employeeDTO) {

            var result = await employeeRepo.GetEmployeeByEmail(employeeDTO.email);
            if ( result != null ) {
                return ApiResponse<bool>.FailResponse("Email đã tồn tại.");
            }
            result = await employeeRepo.GetEmployeeByPhone(employeeDTO.phone);
            if ( result != null ) {
                return ApiResponse<bool>.FailResponse("Số điện thoại đã tồn tại.");
            }
            if ( employeeDTO.address == null ) {
                return ApiResponse<bool>.FailResponse("Địa chỉ không được để trống.");
            }

            try {
                await transactionRepo.BeginTransactionAsync();
                Address address = new() {
                    Province = employeeDTO.address!.province,
                    District = employeeDTO.address!.district,
                    Hamlet = employeeDTO.address!.hamlet,
                    Street = employeeDTO.address.street,
                    HouseNumber = employeeDTO.address.houseNumber,
                };
                await addressRepo.AddAddress(address);
                Employees item = new() {
                    UserName = employeeDTO.username,
                    Fullname = employeeDTO.fullname,
                    Email = employeeDTO.email,
                    Phone = employeeDTO.phone,
                    Password = BCrypt.Net.BCrypt.HashPassword(employeeDTO.password),
                    Address = address,
                    RestaurantId = 1,
                    RoleId = employeeDTO.roleId,
                };
                await employeeRepo.AddEmployee(item);

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Thêm nhân viên thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.ToString());
            }
        }

        public async Task<ApiResponse<bool>> DisableEmployee(int employeeId) {
            var employee = await employeeRepo.GetEmployeeById(employeeId);
            if ( employee == null ) {
                return ApiResponse<bool>.FailResponse("Nhân viên không tồn tại.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();


                employee.IsActive = !employee.IsActive;
                employeeRepo.UpdateEmployee(employee);

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật trạng thái nhân viên thành công.");

            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.ToString());
            }

        }

        public async Task<ApiResponse<IEnumerable<EmployeeResponse>>> GetAllEmployees() {
            var employees = await employeeRepo.GetAllEmployees();
            if ( !employees.Any() ) {
                return ApiResponse<IEnumerable<EmployeeResponse>>.FailResponse("Không có nhân viên");
            }
            IEnumerable<EmployeeResponse> list = employees.Select(e => new EmployeeResponse() {
                employeeId = e.EmployeeId,
                username = e.UserName,
                fullname = e.Fullname,
                email = e.Email,
                phone = e.Phone,
                roleId = e.RoleId,
                roleName = e.Role!.RoleName,
                address = new AddressResponse() {
                    addressId = e.AddressId,
                    province = e.Address!.Province,
                    district = e.Address.District,
                    hamlet = e.Address.Hamlet,
                    street = e.Address.Street,
                    houseNumber = e.Address.HouseNumber

                }
            });
            return ApiResponse<IEnumerable<EmployeeResponse>>.SuccessResponse(list, "Lấy danh sách nhân viên thành công.");
        }

        public async Task<ApiResponse<EmployeeResponse>> GetEmployeeById(int employeeId) {
            var result = await employeeRepo.GetEmployeeById(employeeId);
            if ( result == null ) {
                return ApiResponse<EmployeeResponse>.FailResponse("Nhân viên không tồn tại.");
            }
            EmployeeResponse employeeResponse = new() {
                employeeId = result.EmployeeId,
                username = result.UserName,
                fullname = result.Fullname,
                email = result.Email,
                phone = result.Phone,
                roleId = result.RoleId,
                roleName = result.Role!.RoleName,
                address = new AddressResponse() {
                    addressId = result.AddressId,
                    province = result.Address!.Province,
                    district = result.Address.District,
                    hamlet = result.Address.Hamlet,
                    street = result.Address.Street,
                    houseNumber = result.Address.HouseNumber

                }
            };
            return ApiResponse<EmployeeResponse>.SuccessResponse(employeeResponse, "Lấy thông tin nhân viên thành công.");
        }

        public async Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO) {
            var result = await employeeRepo.GetEmployeeById(employeeDTO.employeeId);
            if ( result == null ) {
                return ApiResponse<bool>.FailResponse("Nhân viên không tồn tại.");

            }
            var checkEmail = await employeeRepo.GetEmployeeByEmail(employeeDTO.email);
            if ( checkEmail != null && checkEmail.EmployeeId != employeeDTO.employeeId ) {
                return ApiResponse<bool>.FailResponse("Email đã tồn tại.");
            }
            var checkPhone = await employeeRepo.GetEmployeeByPhone(employeeDTO.phone);
            if ( checkPhone != null && checkPhone.EmployeeId != employeeDTO.employeeId ) {
                return ApiResponse<bool>.FailResponse("Số điện thoại đã tồn tại.");
            }
            if ( employeeDTO.address == null ) {
                return ApiResponse<bool>.FailResponse("Địa chỉ không được để trống.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                result.Email = employeeDTO.email;
                result.Fullname = employeeDTO.fullname;
                result.Phone = employeeDTO.phone;
                result.UserName = employeeDTO.username;
                if ( !string.IsNullOrEmpty(employeeDTO.password) ) {
                    result.Password = BCrypt.Net.BCrypt.HashPassword(employeeDTO.password);
                }
                result.RoleId = employeeDTO.roleId;
                result.Address!.Province = employeeDTO.address.province;
                result.Address.District = employeeDTO.address.district;
                result.Address.Hamlet = employeeDTO.address.hamlet;
                result.Address.Street = employeeDTO.address.street;
                result.Address.HouseNumber = employeeDTO.address.houseNumber;

                employeeRepo.UpdateEmployee(result);

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật nhân viên thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.ToString());
            }
        }
    }
}
