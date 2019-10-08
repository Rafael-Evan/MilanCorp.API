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
    public class AniversarianteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AniversarianteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAniversariante()
        {
            try
            {
                var results = await _context.Aniversariantes.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("AniversarianteAnoAtual")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAniversarianteAno()
       {
            try
            {
                var results = await _context.Aniversariantes.ToListAsync();

                foreach (var aniversariante in results)
                {
                    var AnoAtual = DateTime.Now.Year;
                    aniversariante.start = new DateTime(AnoAtual, aniversariante.start.Value.Month, aniversariante.start.Value.Day);
                  
                }

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("cadastrarAniversariante")]
        [AllowAnonymous]
        public async Task<ActionResult<Aniversariante>> PostAniversariante(Aniversariante aniversariante)
        {
            aniversariante.id = new Guid();
            _context.Add(aniversariante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAniversariante", new { id = aniversariante.id }, aniversariante);
        }
    }
}
