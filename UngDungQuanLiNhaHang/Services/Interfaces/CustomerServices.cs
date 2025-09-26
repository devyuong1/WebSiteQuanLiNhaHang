using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.IServices {
    public interface CustomerServices {
        
        public  Task<bool> UpdateCustomer(Customers customer);
        public  Task<ApiResponse<CustomerResponse>> GetCustomersById(int id);
        public  Task<bool> AddAddress(AddressDTO address);
        public  Task<bool> UpdateAddress(AddressDTO address);
        public  Task<bool> DeleteAddress(int addressId);

    }
}
