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
    public class FotografiaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public FotografiaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Fotografia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotografium>>> GetFotografia()
        {
            return await _context.Fotografia.ToListAsync();
        }

        // GET: api/Fotografia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fotografium>> GetFotografium(int id)
        {
            var fotografium = await _context.Fotografia.FindAsync(id);

            if (fotografium == null)
            {
                return NotFound();
            }

            return fotografium;
        }

        // PUT: api/Fotografia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFotografium(int id, Fotografium fotografium)
        {
            if (id != fotografium.FotografiaId)
            {
                return BadRequest();
            }

            _context.Entry(fotografium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotografiumExists(id))
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

        // POST: api/Fotografia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fotografium>> PostFotografium(Fotografium fotografium)
        {
            _context.Fotografia.Add(fotografium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FotografiumExists(fotografium.FotografiaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFotografium", new { id = fotografium.FotografiaId }, fotografium);
        }

        // DELETE: api/Fotografia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fotografium>> DeleteFotografium(int id)
        {
            var fotografium = await _context.Fotografia.FindAsync(id);
            if (fotografium == null)
            {
                return NotFound();
            }

            _context.Fotografia.Remove(fotografium);
            await _context.SaveChangesAsync();

            return fotografium;
        }

        private bool FotografiumExists(int id)
        {
            return _context.Fotografia.Any(e => e.FotografiaId == id);
        }
    }
}
