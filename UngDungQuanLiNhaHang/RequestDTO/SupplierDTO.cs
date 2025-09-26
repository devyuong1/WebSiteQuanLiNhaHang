using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class SupplierDTO {
        public int supplierID { get; set; }
        public required string supplierName { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
        public AddressDTO? address { get; set; }
    }
}
