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
    public class CartsController(ICartServices cartServices) : ControllerBase
    {

        // GET: api/Carts/5
        [Authorize]
        [HttpGet("GetCarts")]
        public async Task<ActionResult<ApiResponse<CartResponse>>> GetCarts()
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var cart = await cartServices.GetCartItems(customerId);

            if (!cart.Success)
            {
                return NotFound(cart);
            }

            return Ok(cart);
        }
        // PUT: api/Carts/5
        [HttpDelete("DeleteCartItem")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCartItem(int cartItemId)
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.RemoveFromCart(customerId, cartItemId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        // POST: api/Carts
        [Authorize]
        [HttpPost("AddCartItem")]
        public async Task<ActionResult<ApiResponse<bool>>> AddCartItem([FromBody] AddItemCartDTO addItemCartDTO)
            
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.UpdateCartItem(customerId, addItemCartDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateQuantityCartItem")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateQuantityCartItem(int cartItemId, int quantity) {
            if ( cartItemId <= 0  || quantity <=0) {
                return BadRequest(ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ."));
            }
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.UpdateQuantityCartItem(customerId, cartItemId, quantity);
            if ( result.Success )
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateQuantityCartOption")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateQuantityCartOption( int cartItemId, int cartOptionId, int quantity) {
            if ( cartItemId <= 0 || quantity <= 0 || cartOptionId  <=0) {
                return BadRequest(ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ."));
            }
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.UpdateQuantityCartOption(customerId, cartItemId, cartOptionId, quantity);
            if ( result.Success )
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteCartItemOption")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCartItemOption( int cartItemId, int cartOptionId) {
            if ( cartItemId <= 0 || cartOptionId <= 0 ) {
                return BadRequest(ApiResponse<bool>.FailResponse("Dữ liệu không hợp lệ."));
            }
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized(ApiResponse<bool>.FailResponse("Token không hợp lệ hoặc thiếu thông tin UserID."));

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.DeleteCartItemOption(customerId, cartItemId, cartOptionId);
            if ( result.Success )
                return Ok(result);
            return BadRequest(result);
        }
    }
}
