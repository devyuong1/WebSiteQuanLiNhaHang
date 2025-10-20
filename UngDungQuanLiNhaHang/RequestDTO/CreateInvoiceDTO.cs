namespace UngDungQuanLiNhaHang.RequestDTO {
    public class CreateInvoiceDTO {
        public int addressId {  get; set; }
        public List<int> cartItemId { get; set; } = new List<int>();
        public int paymentMethodId { get; set; }        
    }
}
