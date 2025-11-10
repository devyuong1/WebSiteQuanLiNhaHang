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
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
       
        [HttpPost("Getproducts")]
        public async Task<ActionResult<ApiResponse<PageResponse<ProductResponse>>>> Getproducts([FromBody]ProductPageDTO productPageDTO)
        {
            var products = await productService.GetAllProducts(productPageDTO);
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }
        // GET: api/Products/5
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ApiResponse<ProductDetailResponse>>> GetProductById(int id)
        {
            var products = await productService.GetProductById(id);
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }
        [HttpGet("GetProductByCategoryId/{id}")]
        public async Task<ActionResult<ApiResponse<List<ProductResponse>>>> GetProductByCategoryId(int id) {
            var products = await productService.GetProductByCategoryid(id);
            if (products.Success) {
                return Ok(products);
            }
            return BadRequest(products);
        }
        // GET: api/Products/5
        [HttpGet("GetProductForPut/{id}")]

        public async Task<ActionResult<ApiResponse<PutProductResponse>>> GetProductForPut(int id) {
            var products = await productService.GetProductId(id);
            if ( products.Success ) {
                return Ok(products);
            }
            return BadRequest(products);
        }

        [HttpPost("GetAllProducts")]
        public async Task<ActionResult<ApiResponse<PageResponse<ProductDetailResponse>>>> GetAllProducts([FromBody] ProductPageDTO productPageDTO)
        {
            var products = await productService.GetPageProducts(productPageDTO);
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        [HttpGet("GetListProductTopSelling")]
        public async Task<ActionResult<ApiResponse<List<ProductResponse>>>> GetListProductTopSelling()
        {
            var products = await productService.GetListProductTopSelling();
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        [HttpGet("GetListProductNews")]
        public async Task<ActionResult<ApiResponse<List<ProductResponse>>>> GetListProductNews()
        {
            var products = await productService.GetListProductNews();
            if (products.Success)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }


        [HttpPut("PutProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]
        public async Task<ActionResult<ApiResponse<bool>>> PutProducts([FromBody] UpdateProductDTO updateProductDTO)
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

        public async Task<ActionResult<ApiResponse<int>>> UpdateImgProduct([FromForm] int productId,  IFormFile file)
        {
            var result = await productService.UpdateImgProduct(productId, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("PostProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]
        

        public async Task<ActionResult<ApiResponse<int>>> PostProducts([FromBody] ProductDTO productDTO)
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

        public async Task<ActionResult<ApiResponse<bool>>> AddImgProduct([FromForm] int productId,  IFormFile file)
        {
            var result = await productService.AddImgProduct(productId,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        // DELETE: api/Products/5
        [HttpPut("ActiveProducts")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<bool>>> ActiveProducts(int id)
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
