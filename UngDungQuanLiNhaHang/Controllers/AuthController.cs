using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<ApiResponse<UserDetails>>> Login([FromBody]LoginDTO customer) {
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
        
        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<UserDetails>>> RefreshToken([FromBody] TokenRequestDTO tokenRequest) {
            if (!ModelState.IsValid) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await authServices.RefreshToken(tokenRequest);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("RefreshTokenEmployee")]
        public async Task<ActionResult<ApiResponse<UserDetails>>> RefreshTokenEmployee([FromBody] TokenRequestDTO tokenRequest) {
            if (!ModelState.IsValid) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await authServices.RefreshTokenEmployee(tokenRequest);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("LoginEmployee")]
        public async Task<ActionResult<ApiResponse<UserDetails>>> LoginEmployee([FromBody]LoginDTO employee) {
            if ( !ModelState.IsValid ) {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await authServices.LoginEmployee(employee);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
