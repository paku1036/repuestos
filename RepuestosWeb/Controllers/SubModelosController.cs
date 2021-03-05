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
    public class SubModelosController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public SubModelosController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/SubModelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubModelo>>> GetSubModelos()
        {
            return await _context.SubModelos.ToListAsync();
        }

        // GET: api/SubModelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubModelo>> GetSubModelo(int id)
        {
            var subModelo = await _context.SubModelos.FindAsync(id);

            if (subModelo == null)
            {
                return NotFound();
            }

            return subModelo;
        }

        // PUT: api/SubModelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubModelo(int id, SubModelo subModelo)
        {
            if (id != subModelo.SubModeloId)
            {
                return BadRequest();
            }

            _context.Entry(subModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubModeloExists(id))
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

        // POST: api/SubModelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubModelo>> PostSubModelo(SubModelo subModelo)
        {
            _context.SubModelos.Add(subModelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubModeloExists(subModelo.SubModeloId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubModelo", new { id = subModelo.SubModeloId }, subModelo);
        }

        // DELETE: api/SubModelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubModelo>> DeleteSubModelo(int id)
        {
            var subModelo = await _context.SubModelos.FindAsync(id);
            if (subModelo == null)
            {
                return NotFound();
            }

            _context.SubModelos.Remove(subModelo);
            await _context.SaveChangesAsync();

            return subModelo;
        }

        private bool SubModeloExists(int id)
        {
            return _context.SubModelos.Any(e => e.SubModeloId == id);
        }
    }
}
