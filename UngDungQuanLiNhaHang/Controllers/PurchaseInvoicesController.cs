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
    public class PurchaseInvoicesController(IPurchaseInvoiceServices purchaseInvoiceServices) : ControllerBase
    {
        // GET: api/PurchaseInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiResponse<PurchaseInvoiceResponse>>>> GetpurchaseInvoice(int page = 1)
        {
            var result = await purchaseInvoiceServices.GetAllPurchaseInvoices(page);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // GET: api/PurchaseInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceResponse>>> GetPurchaseInvoice(int id)
        {
            var result = await purchaseInvoiceServices.GetPurchaseInvoiceById(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // PUT: api/PurchaseInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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

        // POST: api/PurchaseInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseInvoice>> PostPurchaseInvoice(PurchaseInvoiceDTO purchaseInvoice)
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
