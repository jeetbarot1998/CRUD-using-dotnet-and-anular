using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly DetailContext _context;

        public DetailController(DetailContext context)
        {
            _context = context;
        }
        // GET: api/PaymentDetail
        [HttpGet]                       
        public async Task<ActionResult<IEnumerable<Detail>>> GetPaymentDetails()
        {
            return await _context.Details.ToListAsync();
        }

        // PUT: api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, Detail detail)
        {
            if (id != detail.PMId)
            {
                return BadRequest();
            }
            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.Details.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // POST: api/PaymentDetail
        [HttpPost]
        public async Task<ActionResult<Detail>> PostPaymentDetail(Detail detail)
        {
            _context.Details.Add(detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = detail.PMId }, detail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.Details.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.Details.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }


        private bool DetailExists(int id)
        {
            return _context.Details.Any(e => e.PMId == id);
        }
    }
}
