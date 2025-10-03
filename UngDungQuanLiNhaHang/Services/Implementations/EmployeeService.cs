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
                Address address = new Address() {
                    Province = employeeDTO.address!.province,
                    District = employeeDTO.address!.district,
                    Hamlet = employeeDTO.address!.hamlet,
                    Street = employeeDTO.address.street,
                    HouseNumber = employeeDTO.address.houseNumber,
                };
                await addressRepo.AddAddress(address);
                Employees item = new Employees() {
                    UserName = employeeDTO.username,
                    Fullname = employeeDTO.fullname,
                    Email = employeeDTO.email,
                    Phone = employeeDTO.phone,
                    Password = BCrypt.Net.BCrypt.HashPassword(employeeDTO.password),
                    addressId = address.AddressId,
                    restaurantId = 1,
                    roleId = employeeDTO.roleId,
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
            if ( employees.Count() == 0 ) {
                return ApiResponse<IEnumerable<EmployeeResponse>>.FailResponse("Không có nhân viên");
            }
            IEnumerable<EmployeeResponse> list = employees.Select(e => new EmployeeResponse() {
                employeeId = e.EmployeeId,
                username = e.UserName,
                fullname = e.Fullname,
                email = e.Email,
                phone = e.Phone,
                roleId = e.roleId,
                roleName = e.roles!.RoleName,
                address = new AddressResponse() {
                    addressId = e.address!.AddressId,
                    province = e.address.Province,
                    district = e.address.District,
                    hamlet = e.address.Hamlet,
                    street = e.address.Street,
                    houseNumber = e.address.HouseNumber
                    
                }
            });
            return ApiResponse<IEnumerable<EmployeeResponse>>.SuccessResponse(list, "Lấy danh sách nhân viên thành công.");
        }

        public Task<ApiResponse<EmployeeResponse>> GetEmployeeById(int employeeId) {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateEmployee(EmployeeDTO employeeDTO) {
            throw new NotImplementedException();
        }
    }
}
