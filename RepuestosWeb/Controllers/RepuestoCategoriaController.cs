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
    public class RepuestoCategoriaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public RepuestoCategoriaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/RepuestoCategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepuestoCategorium>>> GetRepuestoCategoria()
        {
            return await _context.RepuestoCategoria.ToListAsync();
        }

        // GET: api/RepuestoCategoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepuestoCategorium>> GetRepuestoCategorium(int id)
        {
            var repuestoCategorium = await _context.RepuestoCategoria.FindAsync(id);

            if (repuestoCategorium == null)
            {
                return NotFound();
            }

            return repuestoCategorium;
        }

        // PUT: api/RepuestoCategoria/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuestoCategorium(int id, RepuestoCategorium repuestoCategorium)
        {
            if (id != repuestoCategorium.RepuestoCategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(repuestoCategorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestoCategoriumExists(id))
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

        // POST: api/RepuestoCategoria
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RepuestoCategorium>> PostRepuestoCategorium(RepuestoCategorium repuestoCategorium)
        {
            _context.RepuestoCategoria.Add(repuestoCategorium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepuestoCategoriumExists(repuestoCategorium.RepuestoCategoriaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepuestoCategorium", new { id = repuestoCategorium.RepuestoCategoriaId }, repuestoCategorium);
        }

        // DELETE: api/RepuestoCategoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepuestoCategorium>> DeleteRepuestoCategorium(int id)
        {
            var repuestoCategorium = await _context.RepuestoCategoria.FindAsync(id);
            if (repuestoCategorium == null)
            {
                return NotFound();
            }

            _context.RepuestoCategoria.Remove(repuestoCategorium);
            await _context.SaveChangesAsync();

            return repuestoCategorium;
        }

        private bool RepuestoCategoriumExists(int id)
        {
            return _context.RepuestoCategoria.Any(e => e.RepuestoCategoriaId == id);
        }
    }
}
