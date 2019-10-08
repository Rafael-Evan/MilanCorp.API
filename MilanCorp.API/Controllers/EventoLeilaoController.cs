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
    public class EventoLeilaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoLeilaoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetEventoLeilao()
        {
            try
            {
                var results = await _context.EventosLeiloes.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("cadastrarEventoLeilao")]
        [AllowAnonymous]
        public async Task<ActionResult<EventoLeilao>> PostEvento(EventoLeilao eventoLeilao)
        {
            eventoLeilao.Id = new Guid();
            _context.Add(eventoLeilao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoLeilao", new { id = eventoLeilao.Id }, eventoLeilao);
        }

    }
}
