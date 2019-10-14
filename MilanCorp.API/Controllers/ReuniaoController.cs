using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.API.Dtos;
using MilanCorp.Domain.Identity;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReuniaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ReuniaoController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetReuniao()
        {
            try
            {
                IQueryable<Reuniao> query = _context.Reunioes
               .Include(c => c.User);

                return Ok(query);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost("cadastrarReuniao")]
        [AllowAnonymous]
        public async Task<IActionResult> PostReuniao(Reuniao reuniao)
        {
            int count = 0;
            reuniao.Id = new Guid();

            DateTime start = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.start.Hour, reuniao.start.Minute, reuniao.start.Second);
            DateTime end = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.end.Hour, reuniao.end.Minute, reuniao.end.Second);
            reuniao.start = start;
            reuniao.end = end;

            var listaDeReunioes = await _context.Reunioes.ToListAsync();

            foreach (var itemReuniao in listaDeReunioes)
            {
                if (start <= end && itemReuniao.data.Value.Date == reuniao.data.Value.Date)
                {
                    TimeSpan time_Start = new TimeSpan(itemReuniao.start.Hour, itemReuniao.start.Minute, itemReuniao.start.Second);
                    TimeSpan time_End = new TimeSpan(itemReuniao.end.Hour, itemReuniao.end.Minute, itemReuniao.end.Second);
                    TimeSpan now_Start = start.TimeOfDay;
                    TimeSpan now_End = end.TimeOfDay;


                    if (itemReuniao.sala.Equals(reuniao.sala) && itemReuniao.local.Equals(reuniao.local))
                    {
                        if (now_Start >= time_Start && now_End >= time_End)
                        {
                            count = count + 1;
                        }
                        else if (now_Start <= time_Start && now_End <= time_End)
                        {
                            count = count + 1;
                        }
                    }
                }
            }
            if (count > 0)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            _context.Add(reuniao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReuniao", new { id = reuniao.Id }, reuniao);
        }
    }
}
