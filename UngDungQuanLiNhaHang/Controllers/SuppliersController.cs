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
    public class SuppliersController(ISupplierServices supplierServices) : ControllerBase
    {
        

        // GET: api/Suppliers
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<IEnumerable<Suppliers>>>> Getsuppliers(int page = 1)
        {
            var result = await supplierServices.GetAllSuppliers(page);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<SupplierResponse>>> GetSuppliers(int id)
        {
            var result = await supplierServices.GetSupplierById(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<bool>>> PutSuppliers( SupplierDTO suppliers)
        {
            if ( suppliers == null || suppliers.address == null || !ModelState.IsValid ) {
                return BadRequest( ApiResponse<bool>.FailResponse("Supplier data is null"));
            }
            var result = await supplierServices.UpdateSupplier(suppliers);
              if (!result.Success)
              {
                return BadRequest(result);
              }
              return Ok(result);
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<Suppliers>> PostSuppliers(SupplierDTO suppliers)
        {
            if (suppliers == null || suppliers.address == null || !ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.FailResponse("Supplier data is null"));
            }
            var result = await supplierServices.AddSupplier(suppliers);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

       
    }
}
