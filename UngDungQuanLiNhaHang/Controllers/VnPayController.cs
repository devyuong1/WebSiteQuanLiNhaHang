using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;

using UngDungQuanLiNhaHang.Services.Interfaces;
using UngDungQuanLiNhaHang.VnPayLibary;

namespace UngDungQuanLiNhaHang.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController(IVnPayService vnPayService,
        IBookTableServices bookTableServices,
        IInvoiceServices invoiceService,
        Logger<VnPayController> _logger
        ) : ControllerBase {
        

        [HttpGet("PaymentCallbackVnpay")]
        public async Task<IActionResult> PaymentCallbackVnpay() {
            var vnpay = new VnPayLibrary();
            var query = HttpContext.Request.Query;
            _logger.LogInformation("Full callback URL: {Url}", HttpContext.Request.QueryString);
            foreach ( var item in query ) {
                if ( item.Key.StartsWith("vnp_") )
                    vnpay.AddResponseData(item.Key, item.Value);
                _logger.LogInformation("Param: {Key} = {Value}", item.Key, item.Value);

            }
            int orderId = int.Parse(vnpay.GetResponseData("vnp_TxnRef"));
            if ( !query.ContainsKey("vnp_SecureHash") ) {
                _logger.LogError("Missing vnp_SecureHash in callback!");
                //return Redirect($"http://localhost:5173/Payment/Error?reason=missing-signature");
            }
            string vnpSecureHash = query["vnp_SecureHash"].ToString();
            string hashSecret = "ZZ2TQT0NTL3SLVBHR3GV2YIAAG9AQFO8";

            // ✅ Truyền đúng thứ tự: (vnp_SecureHash, HashSecret)
            bool isValid = vnpay.ValidateSignature(vnpSecureHash, hashSecret);
            if ( !isValid ) {
                return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason=invalid-signature");
            }
            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");

            _logger.LogInformation("Signature validation result: {IsValid}", isValid);

            if ( responseCode == "00" && transactionStatus == "00" ) {
                var isSuccess = await invoiceService.UpdatePayMent(orderId); // Cập nhật trạng thái thanh toán  hóa đơn "
                var isDeleteCart = await invoiceService.DeleteCartByInvoiceId(orderId);
                if ( isSuccess.Success == false  || isDeleteCart.Success == false) {
                    return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&&reason=Lỗi hệ thống vui lòng liên hệ nhà hàng để được hỗ trợ.");
                }

                return Redirect($"http://localhost:5173/Payment/Success");
            }

            return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason=Thanh toán thất bại. Vui lòng kiểm tra lại tài khoản.");

        }

        

        [HttpGet("PaymentCallbackDatBan")]
        public async Task<IActionResult> PaymentCallbackDatBan() {
            var vnpay = new VnPayLibrary();
            var query = HttpContext.Request.Query;

            foreach ( var item in query ) {
                if ( item.Key.StartsWith("vnp_") )
                    vnpay.AddResponseData(item.Key, item.Value);
            }

            string vnpSecureHash = query["vnp_SecureHash"].ToString();
            string hashSecret = "ZZ2TQT0NTL3SLVBHR3GV2YIAAG9AQFO8";

            // ✅ Truyền đúng thứ tự: (vnp_SecureHash, HashSecret)
            bool isValid = vnpay.ValidateSignature(vnpSecureHash, hashSecret);

            if ( !isValid ) {
                return Redirect("https://yourfrontend.com/payment-failure?reason=invalid-signature");
            }

            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            string bookTableId = vnpay.GetResponseData("vnp_TxnRef");

            if ( responseCode == "00" && transactionStatus == "00" ) {
                var isUpdatePayment = await bookTableServices.UpdateBookingPayment(int.Parse(bookTableId));
                if (isUpdatePayment.Success) {
                    return Redirect($"http://localhost:5173/DatBanSuccess");
                }
                return Redirect($"http://localhost:5173/DatBanError?bookTableId={bookTableId}&reason=Lỗi hệ thống vui lòng liên hệ nhà hàng để được hỗ trợ.");
            }
            else {
                return Redirect($"http://localhost:5173/DatBanErro?bookTableId={bookTableId}&reason=Thanh toán thất bại. Vui lòng kiểm tra lại tài khoản.");
            }
        }
    }
}
