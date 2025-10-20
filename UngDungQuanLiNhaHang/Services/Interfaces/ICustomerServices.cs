using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ICustomerServices {
        
          Task<ApiResponse<bool>> UpdateCustomer(int customerID, UpdateUserDTO customer);
          Task<ApiResponse<CustomerResponse>> GetCustomersById(int id);
          Task<ApiResponse<bool>> UpdateAddress(int customerID, AddressDTO address);
         Task<ApiResponse<bool>> AddAddress(int customerID,AddressDTO address);
          Task<ApiResponse<bool>> DeleteAddress(int customerId,int addressId);
          Task<ApiResponse<bool>> SetDefaultAddress(int customerId,int addressId);
          Task<ApiResponse<bool>> ChangePassword(int customerId,string oldPassword,string newPassword);
          Task<ApiResponse<AddressResponse>> GetAddressDefault(int customerId);
        Task<ApiResponse<AddressResponse>> GetAddressByIdt(int customerId,int addressId);


    }
}
