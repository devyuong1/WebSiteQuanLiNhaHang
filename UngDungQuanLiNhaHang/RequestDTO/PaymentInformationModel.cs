using Microsoft.Identity.Client;

namespace UngDungQuanLiNhaHang.RequestDTO {
    public class PaymentInformationModel {
        public int id { get; set; }
        public string? OrderType { get; set; }
        public double? Amount { get; set; }
        public string? OrderDescription { get; set; }
        public string? Name { get; set; }


    }
}
