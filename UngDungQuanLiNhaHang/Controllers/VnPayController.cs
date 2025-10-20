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
    public class VnPayController(IVnPayService vnPayService,IInvoiceServices invoiceService,Logger<VnPayController> _logger) : ControllerBase {
        [Authorize]
        [HttpPost("CreatePaymentUrlVnpay")]
        public async Task<ActionResult<ApiResponse<string>>> CreatePaymentUrlVnpay([FromBody] PaymentInformationModel model) {

            
            //var url = vnPayService.CreatePaymentUrl(model, HttpContext, "http://localhost:5030/api/VnPay/PaymentCallbackVnpay", model.id);
            //if ( url == null ) {
            //    return ApiResponse<string>.FailResponse("Lỗi hệ thống.");
            //}
            //return Ok(ApiResponse<string>.SuccessResponse(url));
            return ApiResponse<string>.FailResponse("Lỗi hệ thống.");
        
        }

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
                    return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason={isDeleteCart.Message}");
                }

                return Redirect($"http://localhost:5173/Payment/Success");
            }

            return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason=Thanh toán thất bại");

        }

        [HttpPost("CreatePaymentUrlDatBan")]
        public async Task<IActionResult> CreatePaymentUrlDatBan([FromBody] PaymentInformationModel model) {
            var url = vnPayService.CreatePaymentUrlForBookTable(model, HttpContext, "http://localhost:5030/api/VnPay/PaymentCallbackDatBan", 1);
            if ( url == null ) {
                return NotFound();
            }
            return Ok(url);

        }

        [HttpGet("PaymentCallbackDatBan")]
        public async Task<IActionResult> PaymentCallbackDatBan() {
            var vnpay = new VnPayLibrary();
            var query = HttpContext.Request.Query;

            foreach ( var item in query ) {
                if ( item.Key.StartsWith("vnp_") )
                    vnpay.AddResponseData(item.Key, item.Value);
            }

            string vnp_HashSecret = "ZZ2TQT0NTL3SLVBHR3GV2YIAAG9AQFO8";
            bool isValid = vnpay.ValidateSignature(vnp_HashSecret);

            //if ( !isValid ) {
            //    return Redirect("https://yourfrontend.com/payment-failure?reason=invalid-signature");
            //}

            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            string orderId = vnpay.GetResponseData("vnp_TxnRef");

            if ( responseCode == "00" && transactionStatus == "00" ) {
                return Redirect($"http://localhost:5173/DatBanSuccess");
            }
            else {
                return Redirect($"http://localhost:5173/DatBanError");
            }
        }
    }
}
