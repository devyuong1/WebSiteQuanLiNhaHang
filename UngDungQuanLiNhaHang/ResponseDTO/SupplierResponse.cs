using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class SupplierResponse {
        public int supplierID { get; set; }
        public required string supplierName { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
        public AddressResponse? address { get; set; }
    }
}
