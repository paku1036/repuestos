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
    public class CotizaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public CotizaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Cotiza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotiza>>> GetCotizas()
        {
            return await _context.Cotizas.ToListAsync();
        }

        // GET: api/Cotiza/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotiza>> GetCotiza(int id)
        {
            var cotiza = await _context.Cotizas.FindAsync(id);

            if (cotiza == null)
            {
                return NotFound();
            }

            return cotiza;
        }

        // PUT: api/Cotiza/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotiza(int id, Cotiza cotiza)
        {
            if (id != cotiza.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cotiza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizaExists(id))
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

        // POST: api/Cotiza
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cotiza>> PostCotiza(Cotiza cotiza)
        {
            _context.Cotizas.Add(cotiza);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CotizaExists(cotiza.ClienteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCotiza", new { id = cotiza.ClienteId }, cotiza);
        }

        // DELETE: api/Cotiza/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotiza>> DeleteCotiza(int id)
        {
            var cotiza = await _context.Cotizas.FindAsync(id);
            if (cotiza == null)
            {
                return NotFound();
            }

            _context.Cotizas.Remove(cotiza);
            await _context.SaveChangesAsync();

            return cotiza;
        }

        private bool CotizaExists(int id)
        {
            return _context.Cotizas.Any(e => e.ClienteId == id);
        }
    }
}
