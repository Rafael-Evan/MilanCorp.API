using Microsoft.AspNetCore.Authorization;
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
    public class NotificacaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notificacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetNotificacoes()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        // GET: api/Notificacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacao>> GetNotificacao(Guid id)
        {
            var notificacao = await _context.Notificacoes.FindAsync(id);

            if (notificacao == null)
            {
                return NotFound();
            }

            return notificacao;
        }

        // PUT: api/Notificacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacao(Guid id, Notificacao notificacao)
        {
            if (id != notificacao.Id)
            {
                return BadRequest();
            }
            _context.Entry(notificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacaoExists(id))
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

        // POST: api/Notificacao
        [HttpPost]
        public async Task<ActionResult<Notificacao>> PostNotificacao(Notificacao notificacao)
        {
            notificacao.Data = DateTime.Now;
            _context.Notificacoes.Add(notificacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacao", new { id = notificacao.Id }, notificacao);
        }

        // DELETE: api/Notificacao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notificacao>> DeleteNotificacao(Guid id)
        {
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }

            _context.Notificacoes.Remove(notificacao);
            await _context.SaveChangesAsync();

            return notificacao;
        }

        private bool NotificacaoExists(Guid id)
        {
            return _context.Notificacoes.Any(e => e.Id == id);
        }
    }
}
