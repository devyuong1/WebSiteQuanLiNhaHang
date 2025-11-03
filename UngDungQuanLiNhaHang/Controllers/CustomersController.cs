using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class CustomersController(ICustomerServices customerServices) : ControllerBase
    {
        
        

        // GET: api/Customers/5
        [HttpGet("GetCustomers")]
        [Authorize( Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<CustomerResponse>>> GetCustomers()
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var customers = await customerServices.GetCustomersById(customerId);

            if (!customers.Success)
            {
                return NotFound(customerId);
            }

            return Ok(customers);
        }
        [HttpPut("PutCustomers")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<bool>>> PutCustomers([FromBody] UpdateUserDTO customer)
        {

            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.UpdateCustomer(customerId,customer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("UpdateAddress")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<bool>>> PutAddress([FromBody]  AddressDTO address)
        {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.UpdateAddress(customerId, address);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("AddAddress")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<bool>>> AddAddress([FromBody] AddressDTO address)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.AddAddress(customerId,address);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("ChangePassword")]
        [Authorize(Roles = "Customer")]


        public async Task<ActionResult<ApiResponse<bool>>> ChangePassword([FromBody] ChangePassword changePasswordDTO)

        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.ChangePassword(customerId, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteAddress")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<bool>>> DeleteAddress(int addressId)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.DeleteAddress(customerId, addressId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("SetDefaultAddress")]
        [Authorize(Roles = "Customer")]

        public async Task<ActionResult<ApiResponse<bool>>> SetDefaultAddress(int addressId)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.SetDefaultAddress(customerId, addressId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetAddressDefault")]
        [Authorize(Roles = "Customer")]
        public async Task <ActionResult<ApiResponse<AddressResponse>>> GetAddressDefault() {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.GetAddressDefault(customerId);
            if ( !result.Success ) {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetAddressById")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<AddressResponse>>> GetAddressById(int addressId) {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.GetAddressByIdt(customerId, addressId);
            if ( !result.Success ) {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
