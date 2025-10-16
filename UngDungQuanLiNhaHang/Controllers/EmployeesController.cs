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
        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]

        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> Getemployees(int page = 1)
        {
            var result = await services.GetAllEmployees(page);
            if ( result.Success) {
                return Ok(result.Access);
            }
            return BadRequest(result.Message);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager")]


        public async Task<ActionResult<EmployeeResponse>> GetEmployees(int id)
        {
            if (id <= 0) {
                return BadRequest("Id không hợp lệ");
            }
            var result = await services.GetEmployeeById(id);

            if (result.Success)
            {
                return Ok(result.Access);
            }

            return NotFound(result.Message);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]

        public async Task<IActionResult> PutEmployees(int id, EmployeeDTO item)
        {
            if (id != item.employeeId || !ModelState.IsValid)
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
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(EmployeeDTO employees)
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
