using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
    public class ProductReviewsController(IProductReviewService productReviewService) : ControllerBase
    {
        [HttpPost("CreateProductReview")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateProductReview([FromBody] ProductReviewDTO productReviewDTO)
        {
            var userIdClaim = User.FindFirst("UserID");
            if (userIdClaim == null)
                return Unauthorized("Token không hợp lệ ");
            var customerId = int.Parse(userIdClaim.Value);
            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ ");
            }
            var result = await productReviewService.CreateProductReview(customerId, productReviewDTO);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteProductReview")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductReview([FromQuery] int productReviewId) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var customerId = int.Parse(userIdClaim.Value);
            var result = await productReviewService.DeleteProductReview(customerId,productReviewId);

            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateProductReview")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateProductReview([FromBody] ProductReviewDTO productReviewDTO) {
            var userIdClaim = User.FindFirst("UserID");
            if ( userIdClaim == null )
                return Unauthorized("Token không hợp lệ ");
            var customerId = int.Parse(userIdClaim.Value);
            if ( !ModelState.IsValid ) {
                return BadRequest("Dữ liệu không hợp lệ ");
            }
            var result = await productReviewService.UpdateProductReview(customerId, productReviewDTO);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
