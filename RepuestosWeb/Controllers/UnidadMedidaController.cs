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
    public class UnidadMedidaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public UnidadMedidaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/UnidadMedida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadMedidum>>> GetUnidadMedida()
        {
            return await _context.UnidadMedida.ToListAsync();
        }

        // GET: api/UnidadMedida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedidum>> GetUnidadMedidum(int id)
        {
            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);

            if (unidadMedidum == null)
            {
                return NotFound();
            }

            return unidadMedidum;
        }

        // PUT: api/UnidadMedida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadMedidum(int id, UnidadMedidum unidadMedidum)
        {
            if (id != unidadMedidum.UnidadMedidaId)
            {
                return BadRequest();
            }

            _context.Entry(unidadMedidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidumExists(id))
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

        // POST: api/UnidadMedida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UnidadMedidum>> PostUnidadMedidum(UnidadMedidum unidadMedidum)
        {
            _context.UnidadMedida.Add(unidadMedidum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnidadMedidumExists(unidadMedidum.UnidadMedidaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnidadMedidum", new { id = unidadMedidum.UnidadMedidaId }, unidadMedidum);
        }

        // DELETE: api/UnidadMedida/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadMedidum>> DeleteUnidadMedidum(int id)
        {
            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedidum == null)
            {
                return NotFound();
            }

            _context.UnidadMedida.Remove(unidadMedidum);
            await _context.SaveChangesAsync();

            return unidadMedidum;
        }

        private bool UnidadMedidumExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.UnidadMedidaId == id);
        }
    }
}
