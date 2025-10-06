using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface ICustomerServices {
        
        public  Task<ApiResponse<bool>> UpdateCustomer(int customerID, CustomerDTO customer);
        public  Task<ApiResponse<CustomerResponse>> GetCustomersById(int id);
        public  Task<ApiResponse<bool>> UpdateAddress(int customerID, AddressDTO address);
        public Task<ApiResponse<bool>> AddAddress(int customerID,AddressDTO address);
        public  Task<ApiResponse<bool>> DeleteAddress(int customerId,int addressId);
        public  Task<ApiResponse<bool>> SetDefaultAddress(int customerId,int addressId);
        public  Task<ApiResponse<bool>> ChangePassword(int customerId,string oldPassword,string newPassword);

    }
}
