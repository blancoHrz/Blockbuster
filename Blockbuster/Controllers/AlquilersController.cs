using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blockbuster.Models;

namespace Blockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AlquilersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Alquilers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alquiler>>> GetAlquiler()
        {
            return await _context.Alquiler.ToListAsync();
        }

        // GET: api/Alquilers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alquiler>> GetAlquiler(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);

            if (alquiler == null)
            {
                return NotFound();
            }

            return alquiler;
        }

        // PUT: api/Alquilers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlquiler(int id, Alquiler alquiler)
        {
            if (id != alquiler.idAlquiler)
            {
                return BadRequest();
            }

            _context.Entry(alquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlquilerExists(id))
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

        // POST: api/Alquilers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alquiler>> PostAlquiler(Alquiler alquiler)
        {
            _context.Alquiler.Add(alquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlquiler", new { id = alquiler.idAlquiler }, alquiler);
        }

        // DELETE: api/Alquilers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlquiler(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }

            _context.Alquiler.Remove(alquiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquiler.Any(e => e.idAlquiler == id);
        }
    }
}
