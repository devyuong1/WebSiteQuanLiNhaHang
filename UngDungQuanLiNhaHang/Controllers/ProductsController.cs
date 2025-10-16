using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
       
        [HttpPost]
        public async Task<ActionResult> Getproducts([FromBody]ProductPageDTO productPageDTO)
        {
            var products = await productService.GetAllProducts(productPageDTO);
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProducts(int id)
        {
            var products = await productService.GetProductById(id);
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        






        [HttpPut("PutProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<IActionResult> PutProducts([FromBody] UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid product data.");
            }
            var result = await productService.UpdateProduct(updateProductDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateImgProduct")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<IActionResult> UpdateImgProduct(int productId, [FromForm] List<ImgProductDTO> imgProductDTO)
        {
            var result = await productService.UpdateImgProduct(productId, imgProductDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("PostProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]


        public async Task<ActionResult<Products>> PostProducts([FromBody] ProductDTO productDTO)
        {
            var result = await productService.AddProduct(productDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddImgProduct")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult> AddImgProduct(int productId, [FromForm] List<ImgProductDTO> imgProductDTO)
        {
            var result = await productService.AddImgProduct(productId,imgProductDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        // DELETE: api/Products/5
        [HttpPut("ActiveProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<IActionResult> ActiveProducts(int id)
        {
            var result = await productService.ActiveProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
    }
}
