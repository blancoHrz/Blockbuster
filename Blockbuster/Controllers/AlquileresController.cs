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
    public class AlquileresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AlquileresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Alquileres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alquiler>>> GetAlquileres()
        {
            // Mantener tu lógica y agregar Include para las relaciones
            return await _context.Alquileres
                .Include(a => a.Cliente) // Relación con Cliente
                .Include(a => a.Pelicula) // Relación con Película
                .ToListAsync();
        }

        // GET: api/Alquileres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alquiler>> GetAlquiler(int id)
        {
            // Mantener tu lógica y agregar Include para las relaciones
            var alquiler = await _context.Alquileres
                .Include(a => a.Cliente) // Relación con Cliente
                .Include(a => a.Pelicula) // Relación con Película
                .FirstOrDefaultAsync(a => a.idAlquiler == id);

            if (alquiler == null)
            {
                return NotFound();
            }

            return alquiler;
        }

        // PUT: api/Alquileres/5
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
            return CreatedAtAction("GetCliente", new { id = alquiler.idAlquiler }, alquiler);
            //return NoContent();
        }

        // POST: api/Alquileres
        [HttpPost]
        public async Task<ActionResult<Alquiler>> PostAlquiler(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlquiler", new { id = alquiler.idAlquiler }, alquiler);
        }

        // DELETE: api/Alquileres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlquiler(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }

            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquileres.Any(e => e.idAlquiler == id);
        }
    }
}