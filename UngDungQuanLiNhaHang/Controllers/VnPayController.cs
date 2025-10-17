using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Implementations;
using UngDungQuanLiNhaHang.Services.Interfaces;
using UngDungQuanLiNhaHang.VnPayLibary;

namespace UngDungQuanLiNhaHang.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController(IVnPayService vnPayService,InvoiceService invoiceService) : ControllerBase {
        [Authorize]
        [HttpPost("CreatePaymentUrlVnpay")]
        public async Task<ActionResult<ApiResponse<string>>> CreatePaymentUrlVnpay([FromBody] PaymentInformationModel model) {

            
            var url = vnPayService.CreatePaymentUrl(model, HttpContext, "http://localhost:5030/api/VnPay/PaymentCallbackVnpay", model.id);
            if ( url == null ) {
                return ApiResponse<string>.FailResponse("Lỗi hệ thống.");
            }
            return Ok(ApiResponse<string>.SuccessResponse(url));

        }

        [HttpGet("PaymentCallbackVnpay")]
        public async Task<IActionResult> PaymentCallbackVnpay() {
            var vnpay = new VnPayLibrary();
            var query = HttpContext.Request.Query;

            foreach ( var item in query ) {
                if ( item.Key.StartsWith("vnp_") )
                    vnpay.AddResponseData(item.Key, item.Value);
            }
            int orderId = int.Parse(vnpay.GetResponseData("vnp_TxnRef"));
            string vnp_HashSecret = "ZZ2TQT0NTL3SLVBHR3GV2YIAAG9AQFO8";
            bool isValid = vnpay.ValidateSignature(vnp_HashSecret);
            if ( !isValid ) {
                return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason=invalid-signature");
            }
            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");


            if ( responseCode == "00" && transactionStatus == "00" ) {
                var isSuccess = await invoiceService.UpdateActiveInvoice(orderId,2); // Cập nhật trạng thái hóa đơn thành "Đã đang giao hàng"
                if ( isSuccess.Success == false  ) {
                    return Redirect($"http://localhost:5173/Payment/Error?orderId={orderId}&reason={isSuccess.Message}");
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
