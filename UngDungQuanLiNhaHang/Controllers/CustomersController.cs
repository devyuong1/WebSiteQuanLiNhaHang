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
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApiResponse<CustomerResponse>>> GetCustomers()
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var customers = await customerServices.GetCustomersById(customerId);

            if (!customers.Success)
            {
                return NotFound(customers);
            }

            return Ok(customers);
        }
        [HttpPut("PutCustomers")]
        [Authorize]
        public async Task<IActionResult> PutCustomers([FromBody] CustomerDTO customer)
        {

            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.UpdateCustomer(customerId,customer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("UpdateAddress")]
        [Authorize]
        public async Task<IActionResult> PutAddress([FromBody]  AddressDTO address)
        {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.UpdateAddress(customerId, address);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("AddAddress")]
        [Authorize]
        public async Task<IActionResult> AddAddress([FromBody] AddressDTO address)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.AddAddress(customerId,address);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("ChangePassword")]
        [Authorize]

        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePasswordDTO)

        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.ChangePassword(customerId, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("DeleteAddress")]
        [Authorize]
        public async Task<IActionResult> DeleteAddress([FromBody] AddressCustomerDTO addressCustomerDTO)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.DeleteAddress(customerId, addressCustomerDTO.addressId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("SetDefaultAddress")]
        [Authorize]
        public async Task<IActionResult> SetDefaultAddress([FromBody] AddressCustomerDTO addressCustomerDTO)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await customerServices.SetDefaultAddress(customerId, addressCustomerDTO.addressId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
