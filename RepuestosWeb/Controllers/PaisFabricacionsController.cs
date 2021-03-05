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
    public class PaisFabricacionsController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public PaisFabricacionsController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/PaisFabricacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisFabricacion>>> GetPaisFabricacions()
        {
            return await _context.PaisFabricacions.ToListAsync();
        }

        // GET: api/PaisFabricacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisFabricacion>> GetPaisFabricacion(int id)
        {
            var paisFabricacion = await _context.PaisFabricacions.FindAsync(id);

            if (paisFabricacion == null)
            {
                return NotFound();
            }

            return paisFabricacion;
        }

        // PUT: api/PaisFabricacions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisFabricacion(int id, PaisFabricacion paisFabricacion)
        {
            if (id != paisFabricacion.PaisFabricacionId)
            {
                return BadRequest();
            }

            _context.Entry(paisFabricacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisFabricacionExists(id))
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

        // POST: api/PaisFabricacions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaisFabricacion>> PostPaisFabricacion(PaisFabricacion paisFabricacion)
        {
            _context.PaisFabricacions.Add(paisFabricacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaisFabricacionExists(paisFabricacion.PaisFabricacionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaisFabricacion", new { id = paisFabricacion.PaisFabricacionId }, paisFabricacion);
        }

        // DELETE: api/PaisFabricacions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaisFabricacion>> DeletePaisFabricacion(int id)
        {
            var paisFabricacion = await _context.PaisFabricacions.FindAsync(id);
            if (paisFabricacion == null)
            {
                return NotFound();
            }

            _context.PaisFabricacions.Remove(paisFabricacion);
            await _context.SaveChangesAsync();

            return paisFabricacion;
        }

        private bool PaisFabricacionExists(int id)
        {
            return _context.PaisFabricacions.Any(e => e.PaisFabricacionId == id);
        }
    }
}
