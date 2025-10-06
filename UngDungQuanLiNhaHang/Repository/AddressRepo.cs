using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Repository {
    public class AddressRepo(DataDbConText _context) {
        public async Task<Address?> GetAddressById(int addressId) {
            return await _context.addresses.FindAsync(addressId);
        }

        
        public async Task AddAddress(Address address) {
            var result = await _context.addresses.AddAsync(address);
        }

    }
}
