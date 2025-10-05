using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.IServices {
    public interface ICustomerServices {
        
        public  Task<bool> UpdateCustomer(CustomerDTO customer);
        public  Task<ApiResponse<CustomerResponse>> GetCustomersById(int id);
        public  Task<ApiResponse<bool>> UpdateAddress(AddressDTO address);
        public Task<ApiResponse<bool>> AddAddress(AddressDTO address);
        public  Task<bool> DeleteAddress(int addressId);

    }
}
