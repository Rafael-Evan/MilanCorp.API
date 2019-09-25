using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain;
using MilanCorp.Repository;

namespace MilanCorp.API.Controllers.MLSistema
{
    [Route("api/[controller]")]
    [ApiController]
    public class MlcomitenteController : ControllerBase
    {
        private readonly MLSistemaContext _context;

        public MlcomitenteController(MLSistemaContext context)
        {
            _context = context;
        }

        // GET: api/Mlcomitente
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Mlcomitentes>>> GetMlcomitentes()
        {
            return await _context.Mlcomitentes.ToListAsync();
        }

        // GET: api/Mlcomitente/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Mlcomitentes>> GetMlcomitentes(short id)
        {
            var mlcomitentes = await _context.Mlcomitentes.FindAsync(id);

            if (mlcomitentes == null)
            {
                return NotFound();
            }

            return mlcomitentes;
        }

        // PUT: api/Mlcomitente/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutMlcomitentes(short id, Mlcomitentes mlcomitentes)
        {
            if (id != mlcomitentes.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(mlcomitentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MlcomitentesExists(id))
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

        // POST: api/Mlcomitente
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Mlcomitentes>> PostMlcomitentes(Mlcomitentes mlcomitentes)
        {
            _context.Mlcomitentes.Add(mlcomitentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMlcomitentes", new { id = mlcomitentes.Codigo }, mlcomitentes);
        }

        // DELETE: api/Mlcomitente/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Mlcomitentes>> DeleteMlcomitentes(short id)
        {
            var mlcomitentes = await _context.Mlcomitentes.FindAsync(id);
            if (mlcomitentes == null)
            {
                return NotFound();
            }

            _context.Mlcomitentes.Remove(mlcomitentes);
            await _context.SaveChangesAsync();

            return mlcomitentes;
        }

        private bool MlcomitentesExists(short id)
        {
            return _context.Mlcomitentes.Any(e => e.Codigo == id);
        }
    }
}
