using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeServices services) : ControllerBase
    {

        // GET: api/Employees
        [HttpGet("Getemployees")]
        [Authorize(Roles = "Admin, Manager")]

        public async Task<ActionResult<ApiResponse<PageResponse<EmployeeResponse>>>> Getemployees(int page = 1)
        {
            var result = await services.GetAllEmployees(page);
            if ( result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/Employees/5
        [HttpGet("GetEmployee")]
        [Authorize(Roles = "Admin, Manager")]


        public async Task<ActionResult<ApiResponse<EmployeeResponse>>> GetEmployee(int id)
        {
            if (id <= 0) {
                return BadRequest("Id không hợp lệ");
            }
            var result = await services.GetEmployeeById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutEmployees")]
        [Authorize(Roles = "Admin, Manager")]

        public async Task<ActionResult<ApiResponse<bool>>> PutEmployees([FromBody] EmployeeDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var result = await services.UpdateEmployee(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("PostEmployees")]
        public async Task<ActionResult<ApiResponse<bool>>> PostEmployees([FromBody]EmployeeDTO employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            var result = await services.AddEmployee(employees);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("GetRoles")]
        public async Task<ActionResult<ApiResponse<List<RoleResponse>>>> GetRoles() {
            var roles = await services.GetRoles();
            return Ok(roles);
        }
        // DELETE: api/Employees/5
        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            var result = await services.DisableEmployee(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

      
    }
}
