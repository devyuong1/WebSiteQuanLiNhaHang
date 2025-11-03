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
    public class CategorysController(ICategoryServices categoryService) : ControllerBase
    {
        // GET: api/Categorys
        [HttpGet("Getcategories")]
        [Authorize(Roles = "Admin,Manager,Employee")]

        public async Task<ActionResult<ApiResponse<PageResponse<CategoryResponse>>>> Getcategories([FromQuery] int page = 1)
        {
            var result = await categoryService.GetAllCategories(page);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetListCategory")]
        

        public async Task<ActionResult<ApiResponse<List<CategoryResponse>>>> GetListCategory(int page = 1) {
            var result = await categoryService.GetListCategory();
            if ( !result.Success ) {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET: api/Categorys/5
        [Authorize(Roles = "Admin, Manager, Employee")]
        [HttpGet("GetCategorys/{id}")]
        public async Task<ActionResult<ApiResponse<CategoryResponse>>> GetCategorys(int id)
        {
            var categorys = await categoryService.GetCategoryById(id);
            if (!categorys.Success)
            {
                return NotFound(categorys);
            }
            return Ok(categorys);
        }

        // PUT: api/Categorys/5
        
        [Authorize(Roles = "Admin,Manager,Employee")]
        [HttpPut("PutCategorys")]
        public async Task<ActionResult<ApiResponse<bool>>> PutCategorys([FromBody]CategoryDTO categoryDTO)
        {

            if ( categoryDTO == null || !ModelState.IsValid ) {
                return BadRequest("Category data is null.");
            }
            var result = await categoryService.UpdateCategory(categoryDTO);
              if (!result.Success)
              {
                return BadRequest(result);
              }
              return Ok(result);
        }

        // POST: api/Categorys
       
        [Authorize(Roles = "Admin,Manager,Employee")]
        [HttpPost("PostCategorys")]
        public async Task<ActionResult<ApiResponse<bool>>> PostCategorys([FromBody]CategoryDTO categoryDTO)
        {
            if(categoryDTO == null || !ModelState.IsValid)
            {
                return BadRequest("Category data is null.");
            }
            var result = await categoryService.AddCategory(categoryDTO);
              if (!result.Success)
              {
                return BadRequest(result);
              }
              return Ok(result);
        }

        // PUT: api/Categorys/5
        [Authorize(Roles = "Admin,Manager,Employee")]
        [HttpPut("ActiveCategorys/{id}")]
        public async Task<IActionResult> ActiveCategorys( int id)
        {
           var result = await categoryService.DisableCategory(id);
              if (!result.Success)
              {
                return BadRequest(result);
              }
              return Ok(result);
        }

        
    }
}
