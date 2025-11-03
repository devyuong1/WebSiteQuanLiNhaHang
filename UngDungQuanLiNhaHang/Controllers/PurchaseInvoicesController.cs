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
    public class PurchaseInvoicesController(IPurchaseInvoiceServices purchaseInvoiceServices) : ControllerBase
    {
        // GET: api/PurchaseInvoices
        [HttpGet("GetpurchaseInvoices")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<PageResponse<PurchaseInvoiceResponse>>>> GetpurchaseInvoices([FromQuery]int page = 1)
        {
            var result = await purchaseInvoiceServices.GetAllPurchaseInvoices(page);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetPurchaseInvoiceDashboard")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<purchaseInvoiceDashboard>>> GetPurchaseInvoiceDashboard()
        {
            var result = await purchaseInvoiceServices.GetPurchaseInvoiceDashboard();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpGet("GetPurchaseInvoice")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<PurchaseInvoiceResponse>>> GetPurchaseInvoice(int id) {
            var result = await purchaseInvoiceServices.GetPurchaseInvoiceById(id);
            if ( !result.Success ) {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPut("PutPurchaseInvoice")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<bool>>> PutPurchaseInvoice([FromBody] PurchaseInvoiceDTO purchaseInvoice)
        {
            if ( purchaseInvoice == null || !ModelState.IsValid ) {
                return BadRequest("PurchaseInvoice data is null.");
            }
            var result = await purchaseInvoiceServices.UpdatePurchaseInvoice(purchaseInvoice);
              if (!result.Success)
              {
                return BadRequest(result);
              }
              return Ok(result);
        }

        [HttpPost("PostPurchaseInvoice")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<bool>>> PostPurchaseInvoice([FromBody] PurchaseInvoiceDTO purchaseInvoice)
        {
            if ( purchaseInvoice == null || !ModelState.IsValid ) {
                return BadRequest("PurchaseInvoice data is null.");
            }
            var result = await purchaseInvoiceServices.AddPurchaseInvoice(purchaseInvoice);
            if ( !result.Success ) {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE: api/PurchaseInvoices/
        [HttpPut("PaymentPurchaseInvoice/{id}")]
        [Authorize(Roles = "Admin, Manager, Employee")]

        public async Task<ActionResult<ApiResponse<bool>>> PaymentPurchaseInvoice(int id)
        {
            var result = await purchaseInvoiceServices.PaymentPurchaseInvoice(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
