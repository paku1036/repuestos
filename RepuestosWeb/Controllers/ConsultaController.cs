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
    public class ConsultaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public ConsultaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Consulta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultum>>> GetConsulta()
        {
            return await _context.Consulta.ToListAsync();
        }

        // GET: api/Consulta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultum>> GetConsultum(int id)
        {
            var consultum = await _context.Consulta.FindAsync(id);

            if (consultum == null)
            {
                return NotFound();
            }

            return consultum;
        }

        // PUT: api/Consulta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultum(int id, Consultum consultum)
        {
            if (id != consultum.ConsultaId)
            {
                return BadRequest();
            }

            _context.Entry(consultum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultumExists(id))
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

        // POST: api/Consulta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Consultum>> PostConsultum(Consultum consultum)
        {
            _context.Consulta.Add(consultum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsultumExists(consultum.ConsultaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsultum", new { id = consultum.ConsultaId }, consultum);
        }

        // DELETE: api/Consulta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consultum>> DeleteConsultum(int id)
        {
            var consultum = await _context.Consulta.FindAsync(id);
            if (consultum == null)
            {
                return NotFound();
            }

            _context.Consulta.Remove(consultum);
            await _context.SaveChangesAsync();

            return consultum;
        }

        private bool ConsultumExists(int id)
        {
            return _context.Consulta.Any(e => e.ConsultaId == id);
        }
    }
}
