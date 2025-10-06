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
        [HttpGet]
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int cartItemId)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Carts>> PostCarts([FromBody] AddItemCartDTO addItemCartDTO)
            
        {
            var userIdClaim = User.FindFirst("UserID");

            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ hoặc thiếu thông tin UserID.");

            int customerId = int.Parse(userIdClaim.Value);
            var result = await cartServices.UpdateCartItem(customerId, addItemCartDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

     
      
    }
}
