using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthServices authServices) : ControllerBase {
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<CustomerResponse>>> Login(LoginDTO customer) {
            if (!ModelState.IsValid) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await authServices.Login(customer);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerDTO customer) {
            if (!ModelState.IsValid) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await authServices.Register(customer);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
