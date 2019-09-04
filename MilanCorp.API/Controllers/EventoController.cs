using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetEvento()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("cadastrarEvento")]
        [AllowAnonymous]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            evento.Id = new Guid();
            _context.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

    }
}
