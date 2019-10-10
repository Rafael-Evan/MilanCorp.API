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
    public class ReuniaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReuniaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetReuniao()
        {
            try
            {
                var results = await _context.Reunioes.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("cadastrarReuniao")]
        [AllowAnonymous]
        public async Task<ActionResult<Reuniao>> PostReuniao(Reuniao reuniao)
        {
            reuniao.Id = new Guid();
            DateTime start = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.start.Hour, reuniao.start.Minute, reuniao.start.Second);
            DateTime end = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.end.Hour, reuniao.end.Minute, reuniao.end.Second);
            reuniao.start = start;
            reuniao.end = end;

            _context.Add(reuniao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReuniao", new { id = reuniao.Id }, reuniao);
        }
    }
}
