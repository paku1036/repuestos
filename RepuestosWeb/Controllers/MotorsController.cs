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
    public class MotorsController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public MotorsController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Motors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motor>>> GetMotors()
        {
            return await _context.Motors.ToListAsync();
        }

        // GET: api/Motors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motor>> GetMotor(int id)
        {
            var motor = await _context.Motors.FindAsync(id);

            if (motor == null)
            {
                return NotFound();
            }

            return motor;
        }

        // PUT: api/Motors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotor(int id, Motor motor)
        {
            if (id != motor.MotorId)
            {
                return BadRequest();
            }

            _context.Entry(motor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorExists(id))
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

        // POST: api/Motors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Motor>> PostMotor(Motor motor)
        {
            _context.Motors.Add(motor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MotorExists(motor.MotorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMotor", new { id = motor.MotorId }, motor);
        }

        // DELETE: api/Motors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Motor>> DeleteMotor(int id)
        {
            var motor = await _context.Motors.FindAsync(id);
            if (motor == null)
            {
                return NotFound();
            }

            _context.Motors.Remove(motor);
            await _context.SaveChangesAsync();

            return motor;
        }

        private bool MotorExists(int id)
        {
            return _context.Motors.Any(e => e.MotorId == id);
        }
    }
}
