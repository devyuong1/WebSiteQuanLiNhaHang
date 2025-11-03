using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController(IInvoiceServices invoiceServices) : ControllerBase
    {
        // for customer 
        [HttpPost("CreateInvoiceForpaymentOnline")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<InvoideForPaymentResponse>>> CreateInvoiceForpaymentOnline([FromBody] InvoiceDTO invoiceDTO) {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if (!ModelState.IsValid || invoiceDTO == null) {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            var response = await invoiceServices.CreateInvoiceForOnline(int.Parse(userIdClaim.Value), invoiceDTO,HttpContext);
            if (!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("CreateInvoiceCustomer")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateInvoiceCustomer([FromBody] InvoiceDTO invoiceDTO) {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if ( !ModelState.IsValid || invoiceDTO == null ) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var response = await invoiceServices.CreateInvoiceCustomer(int.Parse(userIdClaim.Value), invoiceDTO);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetInvoicesByCustomerId")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<List<InvoiceForCustomerResponse>>>> GetInvoicesByCustomerId() {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.GetInvoicesByCustomerId(int.Parse(userIdClaim.Value));
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut("CancellInvoiceForCustomer")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> CancellInvoiceForCustomer( int invoiceId) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.CancellInvoiceForCustomer(int.Parse(userIdClaim.Value), invoiceId);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        // tao hóa đơn tại chỗ cho khách hàng
        [HttpPost("CreateInvoiceForOffLine")]
        [Authorize (Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateInvoiceForOffLine([FromBody]  InvoiceOffLineDTO invoice) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if ( !ModelState.IsValid || invoice == null ) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var response = await invoiceServices.CreateInvoiceForOffLine(int.Parse(userIdClaim.Value), invoice);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("CreateInvoiceForBookTable")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateInvoiceForBookTable([FromBody] InvoiceOffLineDTO invoice) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if ( !ModelState.IsValid || invoice == null ) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var response = await invoiceServices.CreateInvoiceForBookTable(int.Parse(userIdClaim.Value), invoice);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("AddInvoiceItem")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> AddInvoiceItem([FromBody] InvoiceItemDTO invoiceItemDTO) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if ( !ModelState.IsValid || invoiceItemDTO == null ) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var response = await invoiceServices.AddInvoiceItem(int.Parse(userIdClaim.Value), invoiceItemDTO);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllInvoicesByDayAndStatusId")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<PageResponse<InvoiceForAdminResponse>>>> GetAllInvoicesByDayAndStatusId([FromQuery]DateTime date,[FromQuery] int page = 1, [FromQuery] int status = 1) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.GetAllInvoicesByDayAndStatusId(date, page, status);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetDetailsInvoiceById")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<InvoiceForAdminResponse>>> GetDetailsInvoiceById([FromQuery] int invoiceid) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.GetInvoiceById(invoiceid);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateStatusInvoice")]
        [Authorize(Roles = "Admin, Employee, Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateStatusInvoice([FromQuery] int invoiceId, [FromQuery] int statusId) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");



            var response = await invoiceServices.UpdateActiveInvoice(invoiceId,statusId,int.Parse(userIdClaim.Value));
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetRevenueByDay")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<RevenueDayResponse>>> GetRevenueByDay([FromQuery] DateTime date) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.GetRevenueByDay(date);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetRevenueByMonth")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<RevenueMonth>>> GetRevenueByMonth([FromQuery]int year) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var response = await invoiceServices.GetRevenueByMonth(year);
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetDashboardSummary")]
        [Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<ActionResult<ApiResponse<DashboardSummaryResponse>>> GetDashboardSummary() {
            
            var response = await invoiceServices.GetDashboardSummary();
            if ( !response.Success ) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
