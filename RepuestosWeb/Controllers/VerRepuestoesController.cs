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
    public class VerRepuestoesController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public VerRepuestoesController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/VerRepuestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerRepuesto>>> GetVerRepuestos()
        {
            return await _context.VerRepuestos.ToListAsync();
        }

        // GET: api/VerRepuestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VerRepuesto>> GetVerRepuesto(int id)
        {
            var verRepuesto = await _context.VerRepuestos.FindAsync(id);

            if (verRepuesto == null)
            {
                return NotFound();
            }

            return verRepuesto;
        }

        // PUT: api/VerRepuestoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerRepuesto(int id, VerRepuesto verRepuesto)
        {
            if (id != verRepuesto.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(verRepuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerRepuestoExists(id))
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

        // POST: api/VerRepuestoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VerRepuesto>> PostVerRepuesto(VerRepuesto verRepuesto)
        {
            _context.VerRepuestos.Add(verRepuesto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VerRepuestoExists(verRepuesto.ClienteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVerRepuesto", new { id = verRepuesto.ClienteId }, verRepuesto);
        }

        // DELETE: api/VerRepuestoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VerRepuesto>> DeleteVerRepuesto(int id)
        {
            var verRepuesto = await _context.VerRepuestos.FindAsync(id);
            if (verRepuesto == null)
            {
                return NotFound();
            }

            _context.VerRepuestos.Remove(verRepuesto);
            await _context.SaveChangesAsync();

            return verRepuesto;
        }

        private bool VerRepuestoExists(int id)
        {
            return _context.VerRepuestos.Any(e => e.ClienteId == id);
        }
    }
}
