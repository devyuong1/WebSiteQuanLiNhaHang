using Microsoft.Identity.Client;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class PaymentInformationModel {
        public int orderId { get; set; }
        public string? OrderType { get; set; }
        public double? Amount { get; set; }
        
        public string? customerId { get; set; }


    }
}
