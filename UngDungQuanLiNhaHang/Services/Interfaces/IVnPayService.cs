using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

namespace UngDungQuanLiNhaHang.Services.Interfaces {
    public interface IVnPayService {
        string CreatePaymentUrl(PaymentInformationModel model, HttpContext context, string urlBack, int orderId);
        string CreatePaymentUrlForBookTable(PaymentInformationModel model, HttpContext context, string urlBack, int bookTabkeId);


        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
