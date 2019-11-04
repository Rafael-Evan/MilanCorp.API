using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventoLeilaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoLeilaoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
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

        [HttpGet("PorData")]
        public async Task<ActionResult> GetEventoLeilaoPorData(DateTime dataInicial, DateTime dataFinal, string nomeDoComitente, string tipoDeLeilao)
        {
            try
            {
                IQueryable<EventoLeilao> eventoLeiloes = _context.EventosLeiloes;

                List<EventoLeilao> eventoLeilao = new List<EventoLeilao>();

                if (nomeDoComitente == null && tipoDeLeilao == null)
                {
                    eventoLeilao = eventoLeiloes.Where(x => x.start >= dataInicial.Date && x.start <= dataFinal.Date).OrderBy(x => x.start).ToList();
                }
                else if (nomeDoComitente != null && tipoDeLeilao == null)
                {
                    eventoLeilao = eventoLeiloes.Where(x => x.start >= dataInicial.Date && x.start <= dataFinal.Date && x.nomeDoComitente == nomeDoComitente).OrderBy(x => x.start).ToList();
                }
                else if (tipoDeLeilao != null && nomeDoComitente == null)
                {
                    eventoLeilao = eventoLeiloes.Where(x => x.start >= dataInicial.Date && x.start <= dataFinal.Date && x.tipoDeLeilao == tipoDeLeilao).OrderBy(x => x.start).ToList();
                }
                else
                {
                    eventoLeilao = eventoLeiloes.Where(x => x.start >= dataInicial.Date && x.start <= dataFinal.Date && x.tipoDeLeilao == tipoDeLeilao && x.nomeDoComitente == nomeDoComitente).OrderBy(x => x.start).ToList();
                }


                return Ok(eventoLeilao);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("cadastrarEventoLeilao")]
        public async Task<ActionResult<EventoLeilao>> PostEvento(EventoLeilao eventoLeilao)
        {
            eventoLeilao.Id = new Guid();
            _context.Add(eventoLeilao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoLeilao", new { id = eventoLeilao.Id }, eventoLeilao);
        }


        // PUT: api/Evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoLeilao(Guid id, EventoLeilao eventoLeilao)
        {
            if (id != eventoLeilao.Id)
            {
                return BadRequest();
            }
            _context.Entry(eventoLeilao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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


        // DELETE: api/Evento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventoLeilao>> CancelarEvento(Guid id)
        {
            var eventoLeilao = await _context.EventosLeiloes.FindAsync(id);
            if (eventoLeilao == null)
            {
                return NotFound();
            }

            _context.EventosLeiloes.Remove(eventoLeilao);
            await _context.SaveChangesAsync();

            return eventoLeilao;
        }

        private bool EventoExists(Guid id)
        {
            return _context.Notificacoes.Any(e => e.Id == id);
        }

    }
}
