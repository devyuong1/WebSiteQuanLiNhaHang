using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.IServices;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class CustomerService(CustomerRepo customerRepo,TransactionRepo transactionRepo) : ICustomerServices {
        

        public Task<bool> DeleteAddress(int addressId) {
            throw new NotImplementedException();
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
        public async Task<ApiResponse<bool>> AddAddress(AddressDTO address) {
            var customer = await customerRepo.GetCustomerForAddress(address.customerId);
            if ( customer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");
            Address address1 = new() {
                Province = address.province,
                District = address.district,
                Hamlet = address.hamlet,
                Street = address.street,
                HouseNumber = address.houseNumber,
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
            
        public async Task<bool> UpdateCustomer(CustomerDTO customer) {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<bool>> UpdateAddress(AddressDTO address) {
            var customer = await customerRepo.GetCustomerForAddress(address.customerId);
            if ( customer == null )
                return ApiResponse<bool>.FailResponse("Customer not found");
            
            var addr = customer.addresses.FirstOrDefault( s=> s.AddressId == address.addressId);
            if ( addr == null) {
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
    }
}
