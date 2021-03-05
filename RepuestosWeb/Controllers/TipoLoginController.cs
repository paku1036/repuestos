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
    public class TipoLoginController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public TipoLoginController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/TipoLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLogin>>> GetTipoLogins()
        {
            return await _context.TipoLogins.ToListAsync();
        }

        // GET: api/TipoLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLogin>> GetTipoLogin(int id)
        {
            var tipoLogin = await _context.TipoLogins.FindAsync(id);

            if (tipoLogin == null)
            {
                return NotFound();
            }

            return tipoLogin;
        }

        // PUT: api/TipoLogin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoLogin(int id, TipoLogin tipoLogin)
        {
            if (id != tipoLogin.TipoLoginId)
            {
                return BadRequest();
            }

            _context.Entry(tipoLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLoginExists(id))
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

        // POST: api/TipoLogin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoLogin>> PostTipoLogin(TipoLogin tipoLogin)
        {
            _context.TipoLogins.Add(tipoLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoLoginExists(tipoLogin.TipoLoginId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoLogin", new { id = tipoLogin.TipoLoginId }, tipoLogin);
        }

        // DELETE: api/TipoLogin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoLogin>> DeleteTipoLogin(int id)
        {
            var tipoLogin = await _context.TipoLogins.FindAsync(id);
            if (tipoLogin == null)
            {
                return NotFound();
            }

            _context.TipoLogins.Remove(tipoLogin);
            await _context.SaveChangesAsync();

            return tipoLogin;
        }

        private bool TipoLoginExists(int id)
        {
            return _context.TipoLogins.Any(e => e.TipoLoginId == id);
        }
    }
}
