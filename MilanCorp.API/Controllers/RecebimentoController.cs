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
    public class RecebimentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecebimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Recebimento
        [HttpGet]
        public async Task<ActionResult> GetRecebimentos()
        {
            try
            {
                IQueryable<Recebimento> query = _context.Recebimentos
               .Include(c => c.User);

                return Ok(query);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        //[HttpGet("MeusRecebimentos")]
        //public async Task<ActionResult> GetMeusRecebimentoss(int userId)
        //{
        //    try
        //    {
        //        var ListaDeferias = await _context.Recebimentos.ToListAsync();

        //        var meusRecebimentos = from recebimentos in ListaDeferias
        //                               where rece && recebimentos.Status == "Aguardando Retirada"
        //                               select new { recebimentos };

        //        return Ok(meusRecebimentos);
        //    }
        //    catch (Exception)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
        //    }
        //}

        // GET: api/Recebimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recebimento>> GetRecebimento(Guid id)
        {
            var recebimento = await _context.Recebimentos.FindAsync(id);

            if (recebimento == null)
            {
                return NotFound();
            }

            return recebimento;
        }

        // PUT: api/Recebimento/5
        [HttpPut()]
        public async Task<IActionResult> PutMeusRecebimentos(Guid id, string status)
        {

            var recebimento = await _context.Recebimentos.FindAsync(id);
            {
                if (id != recebimento.Id)
                {
                    return BadRequest();
                }

                recebimento.Status = status;
                _context.Entry(recebimento).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecebimentoExists(id))
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
        }

        // POST: api/Recebimento
        [HttpPost]
        public async Task<ActionResult<Recebimento>> PostRecebimento(Recebimento recebimento)
        {
            recebimento.Id = new Guid();
            recebimento.Status = "Aguardando Retirada";
            _context.Recebimentos.Add(recebimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecebimento", new { id = recebimento.Id }, recebimento);
        }

        // DELETE: api/Recebimento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recebimento>> DeleteRecebimento(Guid id)
        {
            var recebimento = await _context.Recebimentos.FindAsync(id);
            if (recebimento == null)
            {
                return NotFound();
            }

            _context.Recebimentos.Remove(recebimento);
            await _context.SaveChangesAsync();

            return recebimento;
        }

        private bool RecebimentoExists(Guid id)
        {
            return _context.Recebimentos.Any(e => e.Id == id);
        }
    }
}
