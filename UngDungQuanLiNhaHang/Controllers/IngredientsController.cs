using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController(IIngredientServices services) : ControllerBase
    {
        

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientResponse>>>> Getingredients(int page = 1)
        {
            var result = await services.GetAllIngredients(page);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<IngredientResponse>>> GetIngredient(int id)
        {
            var result = await services.GetIngredientById(id);

            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, IngredientDTO ingredient)
        {
            if (id != ingredient.ingredientId || !ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            var result = await services.UpdateIngredient(ingredient);
            if ( result.Success ) {
                return Ok(result);
            }   
            return BadRequest(result);
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient([FromBody]IngredientDTO ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await services.AddIngredient(ingredient);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ActiveIngredient(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var result = await services.DisableIngredient(id);
            if ( result.Success ) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
    }
}
