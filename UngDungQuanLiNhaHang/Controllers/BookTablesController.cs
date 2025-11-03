using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTablesController(IBookTableServices bookTableServices) : ControllerBase
    {
        // for admin , manager , employee

        // GET: api/BookTables
        [HttpGet("GetAllBookingsAsync")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<PageResponse<BookTableResponse>>>> GetAllBookingsAsync([FromQuery] DateTime time, [FromQuery] int page = 1) {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");

            var bookings = await bookTableServices.GetAllBookingsAsync(time, page);
            if (!bookings.Success) {
                return NotFound(bookings);
            }
            return Ok(bookings);
        }
        [HttpGet("GetBookingsByStatusIdAsync")]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<ActionResult<ApiResponse<PageResponse<BookTableResponse>>>> GetBookingsByStatusIdAsync([FromQuery] string  time, [FromQuery] int id, [FromQuery] int page = 1) {
                var userIdClaim = User.FindFirst("UserID");
            
                if ( userIdClaim == null )
                 return Unauthorized("Token không hợp lệ ");
                DateTime date;
                var formats = new[] { "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd" };
                if ( !DateTime.TryParseExact(time, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ) {
                    return BadRequest(new ApiResponse<string> {
                        Success = false,
                        Message = $"Định dạng ngày không hợp lệ ({time}). Hãy dùng định dạng yyyy-MM-dd hoặc dd/MM/yyyy."
                    });
                }
            var bookings = await bookTableServices.GetBookingsByStatusIdAsync(date, id, page);
                
                return Ok(bookings);
        }
        [HttpGet("UpdateBookingStatusAsync")]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateBookingStatusAsync([FromQuery] int bookTableId, [FromQuery] int statusID) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var bookings = await bookTableServices.UpdateBookingStatusAsync(bookTableId, statusID);
            if (!bookings.Success) {
                return NotFound(bookings);
            }
            return Ok(bookings);
        }
        // for customer
        [HttpPost("CreateBooking")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<string>>> CreateBooking( [FromBody] BookTableDTO dto) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            if (!ModelState.IsValid) {
                return BadRequest("Dữ liệu không hợp lệ ");
            }
            var bookings = await bookTableServices.CreateBookingAsync(int.Parse(userIdClaim.Value), dto,HttpContext);
            if (!bookings.Success) {
                return BadRequest(bookings);
            }
            return Ok(bookings);
        }
        [HttpPut("CancelBookingAsync")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelBookingAsync(  int bookTableId) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var bookings = await bookTableServices.CancelBookingAsync(int.Parse(userIdClaim.Value), bookTableId);
            if (!bookings.Success) {
                return NotFound(bookings);
            }
            return Ok(bookings);
        }
        [HttpGet("GetBookingsByCustomerAsync")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<List<BookTableResponse>>>> GetBookingsByCustomerAsync() {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var bookings = await bookTableServices.GetBookingsByCustomerAsync(int.Parse(userIdClaim.Value));
            if (!bookings.Success) {
                return NotFound(bookings);
            }
            return Ok(bookings);
        }
        [HttpPost("GetTableByDay")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<List<TableResponse>>>> GetTableByDay([FromBody] BookTableDTO dto) {
            if ( !ModelState.IsValid ) {
                return BadRequest(ApiResponse<List<TableResponse>>.FailResponse("Dữ liệu lỗi."));
            }
            var result = await bookTableServices.GetTablesByDate(dto.bookingDate, dto.numberOfGuests);
            if ( !result.Success ) { 
                return BadRequest(ApiResponse<List<TableResponse>>.FailResponse("Không tìm tháy dữ liệu."));

            }
            return Ok(result);
        }
    }
}
