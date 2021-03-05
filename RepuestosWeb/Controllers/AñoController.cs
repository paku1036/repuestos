using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepuestosWeb.Models;

namespace RepuestosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AñoController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public AñoController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Año
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Año>>> GetAños()
        {
            return await _context.Años.ToListAsync();
        }

        // GET: api/Año/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Año>> GetAño(int id)
        {
            var año = await _context.Años.FindAsync(id);

            if (año == null)
            {
                return NotFound();
            }

            return año;
        }

        // PUT: api/Año/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAño(int id, Año año)
        {
            if (id != año.AñoId)
            {
                return BadRequest();
            }

            _context.Entry(año).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AñoExists(id))
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

        // POST: api/Año
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Año>> PostAño(Año año)
        {
            _context.Años.Add(año);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AñoExists(año.AñoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAño", new { id = año.AñoId }, año);
        }

        // DELETE: api/Año/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Año>> DeleteAño(int id)
        {
            var año = await _context.Años.FindAsync(id);
            if (año == null)
            {
                return NotFound();
            }

            _context.Años.Remove(año);
            await _context.SaveChangesAsync();

            return año;
        }

        private bool AñoExists(int id)
        {
            return _context.Años.Any(e => e.AñoId == id);
        }
    }
}
