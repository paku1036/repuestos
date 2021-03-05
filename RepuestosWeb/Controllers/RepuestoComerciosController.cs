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
    public class RepuestoComerciosController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public RepuestoComerciosController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/RepuestoComercios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepuestoComercio>>> GetRepuestoComercios()
        {
            return await _context.RepuestoComercios.ToListAsync();
        }

        // GET: api/RepuestoComercios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepuestoComercio>> GetRepuestoComercio(int id)
        {
            var repuestoComercio = await _context.RepuestoComercios.FindAsync(id);

            if (repuestoComercio == null)
            {
                return NotFound();
            }

            return repuestoComercio;
        }

        // PUT: api/RepuestoComercios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuestoComercio(int id, RepuestoComercio repuestoComercio)
        {
            if (id != repuestoComercio.ComercioId)
            {
                return BadRequest();
            }

            _context.Entry(repuestoComercio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestoComercioExists(id))
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

        // POST: api/RepuestoComercios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RepuestoComercio>> PostRepuestoComercio(RepuestoComercio repuestoComercio)
        {
            _context.RepuestoComercios.Add(repuestoComercio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepuestoComercioExists(repuestoComercio.ComercioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepuestoComercio", new { id = repuestoComercio.ComercioId }, repuestoComercio);
        }

        // DELETE: api/RepuestoComercios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepuestoComercio>> DeleteRepuestoComercio(int id)
        {
            var repuestoComercio = await _context.RepuestoComercios.FindAsync(id);
            if (repuestoComercio == null)
            {
                return NotFound();
            }

            _context.RepuestoComercios.Remove(repuestoComercio);
            await _context.SaveChangesAsync();

            return repuestoComercio;
        }

        private bool RepuestoComercioExists(int id)
        {
            return _context.RepuestoComercios.Any(e => e.ComercioId == id);
        }
    }
}
