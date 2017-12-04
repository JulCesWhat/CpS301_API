using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CpS301_API.Models;

namespace CpS301_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Serviceevents")]
    public class ServiceeventsController : Controller
    {
        private readonly wsoappContext _context;

        public ServiceeventsController(wsoappContext context)
        {
            _context = context;
        }

        // GET: api/Serviceevents
        [HttpGet]
        public IEnumerable<Serviceevent> GetServiceevent()
        {
            return _context.Serviceevent;
        }

        // GET: api/Serviceevents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceevent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceevent = await _context.Serviceevent.SingleOrDefaultAsync(m => m.EventId == id);

            if (serviceevent == null)
            {
                return NotFound();
            }

            return Ok(serviceevent);
        }

        // PUT: api/Serviceevents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceevent([FromRoute] int id, [FromBody] Serviceevent serviceevent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceevent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(serviceevent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceeventExists(id))
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

        // POST: api/Serviceevents
        [HttpPost]
        public async Task<IActionResult> PostServiceevent([FromBody] Serviceevent serviceevent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Serviceevent.Add(serviceevent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceevent", new { id = serviceevent.EventId }, serviceevent);
        }

        // DELETE: api/Serviceevents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceevent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceevent = await _context.Serviceevent.SingleOrDefaultAsync(m => m.EventId == id);
            if (serviceevent == null)
            {
                return NotFound();
            }

            _context.Serviceevent.Remove(serviceevent);
            await _context.SaveChangesAsync();

            return Ok(serviceevent);
        }

        private bool ServiceeventExists(int id)
        {
            return _context.Serviceevent.Any(e => e.EventId == id);
        }
    }
}