using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CustomerService(CustomerRepo customerRepo, TransactionRepo transactionRepo) : ICustomerServices {


        public async Task<ApiResponse<bool>> DeleteAddress(int customerId, int addressId) {
            var customer = await customerRepo.GetCustomerById(customerId);
            if ( customer == null ) {
                return ApiResponse<bool>.FailResponse("Customer not found");
            }
            var address = customer.addresses.FirstOrDefault(a => a.AddressId == addressId);
            if ( address == null ) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                customer.addresses.Remove(address);
                customerRepo.UpdateCustomer(customer);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Delete address successfully");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Delete address failed. Erorr : " + ex.ToString());
            }
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomersById(int id) {
            var customer = await customerRepo.GetCustomerById(id);
            if ( customer == null )
                return ApiResponse<CustomerResponse>.FailResponse("Customer not found");
            var response = new CustomerResponse() {
                customerId = customer.CustomerId,
                fullName = customer.FullName,
                email = customer.Email,
                phone = customer.Phone,
                address = customer.addresses.Select(a => new AddressResponse {
                    addressId = a.AddressId,
                    province = a.Province,
                    district = a.District,
                    hamlet = a.Hamlet,
                    street = a.Street,
                    houseNumber = a.HouseNumber,
                    isDefault = a.IsDefault
                }).ToList()
            };

            return ApiResponse<CustomerResponse>.SuccessResponse(response, "Get customer successfully");

        }
        public async Task<ApiResponse<bool>> AddAddress(int customerID, AddressDTO address) {
            var customer = await customerRepo.GetCustomerForAddress(customerID);
            if ( customer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");
            if (address.isDefault) {
                foreach ( var item in customer.addresses ) {
                    item.IsDefault = false;
                }
            }
            Address address1 = new() {
                Province = address.province,
                District = address.district,
                Hamlet = address.hamlet,
                Street = address.street,
                HouseNumber = address.houseNumber,
                IsDefault = address.isDefault,
            };
            var addr = customer.addresses.Contains(address1);
            if ( !addr ) {
                try {
                    await transactionRepo.BeginTransactionAsync();
                    customer.addresses.Add(address1);
                    customerRepo.UpdateCustomer(customer);
                    await transactionRepo.CompleteAsync();
                    await transactionRepo.CommitAsync();
                    return ApiResponse<bool>.SuccessResponse(true, "Add address successfully");
                }
                catch ( Exception ex ) {
                    await transactionRepo.RollbackAsync();
                    return ApiResponse<bool>.FailResponse("Add address failed");

                }
            }

            return ApiResponse<bool>.FailResponse("Address is exist");
        }

        public async Task<ApiResponse<bool>> UpdateCustomer(int customerID, CustomerDTO customer) {
            var existingCustomer = await customerRepo.GetCustomerById(customerID);
            if ( existingCustomer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");
            existingCustomer.FullName = customer.FullName;
            existingCustomer.Phone = customer.Phone;

            try {
                await transactionRepo.BeginTransactionAsync();
                customerRepo.UpdateCustomer(existingCustomer);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Update Success");

            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse(ex.Message);
            }


        }

        public async Task<ApiResponse<bool>> UpdateAddress(int customerID, AddressDTO address) {
            var customer = await customerRepo.GetCustomerForAddress(customerID);
            if ( customer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");

            var addr = customer.addresses.FirstOrDefault(s => s.AddressId == address.addressId);
            if ( addr == null ) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }
            addr.Province = address.province;
            addr.District = address.district;
            addr.Hamlet = address.hamlet;
            addr.Street = address.street;
            addr.HouseNumber = address.houseNumber;
            addr.IsDefault = address.isDefault;
            try {
                await transactionRepo.BeginTransactionAsync();
                customer.addresses.Add(addr);
                customerRepo.UpdateCustomer(customer);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Update address successfully");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Update address failed");

            }

        }

        public async Task<ApiResponse<bool>> SetDefaultAddress(int customerId, int addressId) {
            var customer = await customerRepo.GetCustomerById(customerId);
            if ( customer == null ) {
                return ApiResponse<bool>.FailResponse("Customer not found");
            }
            var addressOld = customer.addresses.FirstOrDefault(a => a.IsDefault == true);
            var addressNew = customer.addresses.FirstOrDefault(a => a.AddressId == addressId);

            if ( addressNew == null ) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }
            if ( addressOld != null ) {
                addressOld.IsDefault = false;
            }
            addressNew.IsDefault = true;
            try {
                await transactionRepo.BeginTransactionAsync();
                customerRepo.UpdateCustomer(customer);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Set default address successfully");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Set default address failed. Error: " + ex.ToString());
            }
        }

        public async Task<ApiResponse<bool>> ChangePassword(int customerId, string oldPassword, string newPassword) {
            var customer = await customerRepo.GetCustomerById(customerId);
            if ( customer == null ) {
                return ApiResponse<bool>.FailResponse("Customer not found");
            }
            if ( !BCrypt.Net.BCrypt.Verify(oldPassword, customer.Password) ) {
                return ApiResponse<bool>.FailResponse("Old password is incorrect");
            }
            customer.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            try {
                await transactionRepo.BeginTransactionAsync();
                customerRepo.UpdateCustomer(customer);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Change password successfully");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Change password failed. Error: " + ex.ToString());
            }
        }
    }
}
