using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CustomerService(CustomerRepo customerRepo, TransactionRepo transactionRepo,AddressRepo addressRepo) : ICustomerServices {


        public async Task<ApiResponse<bool>> DeleteAddress(int customerId, int addressId) {
            var customer = await customerRepo.GetCustomerById(customerId);
            if ( customer == null ) {
                return ApiResponse<bool>.FailResponse("Customer not found");
            }
            var address = customer.AddressCustomers.FirstOrDefault(a => a.AddressId == addressId);
            if ( address == null ) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                customer.AddressCustomers.Remove(address);
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
                address = customer.AddressCustomers
                .Where(a => a.Address != null)
                    .Select(a => new AddressResponse {
                        addressId = a.AddressId,
                        province = a.Address!.Province,
                        district = a.Address.District,
                        hamlet = a.Address.Province,
                        street = a.Address.Street,
                        houseNumber = a.Address.Province,
                        isDefault = a.Address.IsDefault
                    })
                    .ToList()
            };

            return ApiResponse<CustomerResponse>.SuccessResponse(response, "Get customer successfully");

        }
        public async Task<ApiResponse<bool>> AddAddress(int customerID, AddressDTO address) {
            var customer = await customerRepo.GetCustomerForAddress(customerID);
            if ( customer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");

            if (address.isDefault) {
                foreach ( var item in customer.AddressCustomers ) {
                    if ( item.Address != null ) {
                        item.Address.IsDefault = false;
                    }
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
            var addr = customer.AddressCustomers.Any(item =>
                            item.Address.Province == address1.Province &&
                            item.Address.District == address1.District &&
                            item.Address.Hamlet == address1.Hamlet &&
                            item.Address.Street == address1.Street &&
                            item.Address.HouseNumber == address1.HouseNumber
                        );
            if ( !addr ) {
                try {
                    await transactionRepo.BeginTransactionAsync();
                    await addressRepo.AddAddress(address1);
                    await transactionRepo.CompleteAsync();
                    AddressCustomer addressCustomer = new AddressCustomer() {
                        CustomerId = customer.CustomerId,
                        AddressId = address1.AddressId
                    };
                    customer.AddressCustomers.Add(addressCustomer);

                    
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

        public async Task<ApiResponse<bool>> UpdateCustomer(int customerID, UpdateUserDTO customer) {
            var existingCustomer = await customerRepo.GetCustomerById(customerID);
            if ( existingCustomer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");
            existingCustomer.FullName = customer.fullName;
            existingCustomer.Phone = customer.phone;

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

            var addr = customer.AddressCustomers.FirstOrDefault(s => s.AddressId == address.addressId);
            if ( addr == null || addr.Address == null ) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }
            addr.Address.Province = address.province;
            addr.Address.District = address.district;
            addr.Address.Hamlet = address.hamlet;
            addr.Address.Street = address.street;
            addr.Address.HouseNumber = address.houseNumber;
            if ( address.isDefault ) {
                foreach ( var item in customer.AddressCustomers ) {
                    if ( item.Address != null ) {
                        item.Address.IsDefault = false;
                    }
                }
                addr.Address.IsDefault = true;
            }
            else {
                addr.Address.IsDefault = false;
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                
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
           
            var addressNew = customer.AddressCustomers.FirstOrDefault(a => a.AddressId == addressId);

            if ( addressNew == null || addressNew.Address == null) {
                return ApiResponse<bool>.FailResponse("Address not found");
            }

            foreach ( var item in customer.AddressCustomers ) {
                if ( item.Address != null ) {
                    item.Address.IsDefault = false;
                }
            }
            addressNew.Address.IsDefault = true;
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

        public async Task<ApiResponse<AddressResponse>> GetAddressDefault(int customerId) {
            var customer = await customerRepo.GetCustomerForAddress(customerId);
            if ( customer == null || !customer.AddressCustomers.Any() ) { return ApiResponse<AddressResponse>.FailResponse("Error1"); }
            var address = customer.AddressCustomers.Where( s => s.Address != null && s.Address.IsDefault == true ).FirstOrDefault();
            if ( address == null || address.Address == null )
                return ApiResponse<AddressResponse>.FailResponse("Error2");

            AddressResponse addressResponse = new() {
                addressId = address.AddressId,
                province = address.Address.Province,
                district = address.Address.District,
                hamlet = address.Address.Hamlet,
                street = address.Address.Street,
                houseNumber = address.Address.HouseNumber,
                isDefault = address.Address.IsDefault,
            };
            return ApiResponse<AddressResponse>.SuccessResponse(addressResponse);
        }

        public async Task<ApiResponse<AddressResponse>> GetAddressByIdt(int customerId, int addressId) {
            var result = await customerRepo.GetAddressById(customerId, addressId);
            if ( result == null || result.Address == null ) {
                return ApiResponse<AddressResponse>.FailResponse("Address not found.");
            }
            AddressResponse addressResponse = new AddressResponse() {
                addressId = addressId,
                province = result.Address.Province,
                district= result.Address.District,
                hamlet= result.Address.Hamlet,
                street = result.Address.Street,
                houseNumber = result.Address.HouseNumber,
                isDefault = result.Address.IsDefault,
            };
            return ApiResponse<AddressResponse> .SuccessResponse(addressResponse);
        }
    }
}
