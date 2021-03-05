﻿using System;
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
    public class CategoriaController : ControllerBase
    {
        private readonly RepuestosFContext _context;

        public CategoriaController(RepuestosFContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorium>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorium>> GetCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);

            if (categorium == null)
            {
                return NotFound();
            }

            return categorium;
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorium(int id, Categorium categorium)
        {
            if (id != categorium.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriumExists(id))
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

        // POST: api/Categoria
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategorium(Categorium categorium)
        {
            _context.Categoria.Add(categorium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriumExists(categorium.CategoriaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategorium", new { id = categorium.CategoriaId }, categorium);
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categorium>> DeleteCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            await _context.SaveChangesAsync();

            return categorium;
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaId == id);
        }
    }
}
