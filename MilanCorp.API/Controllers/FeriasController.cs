using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FeriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("MinhaSolicitacaoDeFerias")]
        public async Task<ActionResult> GetMinhaSolicitacaoDeFerias(int userId)
        {
            try
            {
                var ListaDeferias = await _context.Ferias.ToListAsync();

                var minhaSolicitacao =  from ferias in ListaDeferias
                                        where ferias.UserId == userId && ferias.DataDaSolicitacao.AddDays(ferias.Expirar) >= DateTime.Now
                                        select new { ferias };

                return Ok(minhaSolicitacao);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }


        [HttpGet]
        public async Task<ActionResult> GetFerias()
        {
            try
            {
                var results = await _context.Ferias.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ferias>> PostFerias(Ferias ferias)
        {
            ferias.Id = new Guid();
            ferias.Status = "Aguardando Retorno do RH";
            ferias.DataDaSolicitacao = DateTime.Now;
            ferias.Expirar = 7;
            _context.Add(ferias);
            await _context.SaveChangesAsync();

            return Ok(ferias);
        }


        [HttpPut()]
        public async Task<IActionResult> AtualizarStatusDaSolicitacaoDeFerias(Guid id, string status)
        {
            var ferias = await _context.Ferias.FindAsync(id);

            if (id != ferias.Id)
            {
                return BadRequest();
            }
            if (status == "Aprovado")
            {
                ferias.Status = status;
                _context.Entry(ferias).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else if (status == "Recusado")
            {
                ferias.Status = status;
                _context.Entry(ferias).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return BadRequest();
            }
            return NoContent();
        }

        private bool FeriasExists(Guid id)
        {
            return _context.Ferias.Any(e => e.Id == id);
        }
    }
}
