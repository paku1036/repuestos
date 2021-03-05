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
    public class LoginLogsController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public LoginLogsController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/LoginLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginLog>>> GetLoginLogs()
        {
            return await _context.LoginLogs.ToListAsync();
        }

        // GET: api/LoginLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginLog>> GetLoginLog(int id)
        {
            var loginLog = await _context.LoginLogs.FindAsync(id);

            if (loginLog == null)
            {
                return NotFound();
            }

            return loginLog;
        }

        // PUT: api/LoginLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginLog(int id, LoginLog loginLog)
        {
            if (id != loginLog.LoginLogId)
            {
                return BadRequest();
            }

            _context.Entry(loginLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginLogExists(id))
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

        // POST: api/LoginLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoginLog>> PostLoginLog(LoginLog loginLog)
        {
            _context.LoginLogs.Add(loginLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginLogExists(loginLog.LoginLogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginLog", new { id = loginLog.LoginLogId }, loginLog);
        }

        // DELETE: api/LoginLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginLog>> DeleteLoginLog(int id)
        {
            var loginLog = await _context.LoginLogs.FindAsync(id);
            if (loginLog == null)
            {
                return NotFound();
            }

            _context.LoginLogs.Remove(loginLog);
            await _context.SaveChangesAsync();

            return loginLog;
        }

        private bool LoginLogExists(int id)
        {
            return _context.LoginLogs.Any(e => e.LoginLogId == id);
        }
    }
}
