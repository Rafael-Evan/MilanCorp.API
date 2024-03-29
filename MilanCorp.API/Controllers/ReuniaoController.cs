﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [AllowAnonymous]
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
        public async Task<IActionResult> PostReuniao(Reuniao reuniao)
        {
            //int count = 0;
            reuniao.Id = new Guid();

            DateTime start = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.start.Hour, reuniao.start.Minute, reuniao.start.Second);
            DateTime end = new DateTime(reuniao.data.Value.Year, reuniao.data.Value.Month, reuniao.data.Value.Day, reuniao.end.Hour, reuniao.end.Minute, reuniao.end.Second);
            reuniao.start = start;
            reuniao.end = end;

            var listaDeReunioes = await _context.Reunioes.ToListAsync();

            var reuniaoDuplicada =
             (from reun in listaDeReunioes
              where reun.sala == reuniao.sala && reun.local == reuniao.local
              && start > reun.start && start < reun.end || end > reun.start && end < reun.end
              select reun.Id).Count();

            if (reuniaoDuplicada > 0)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            _context.Add(reuniao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReuniao", new { id = reuniao.Id }, reuniao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reuniao>> DeleteReuniao(Guid id)
        {
            var reuniao = await _context.Reunioes.FindAsync(id);
            if (reuniao == null)
            {
                return NotFound();
            }

            _context.Reunioes.Remove(reuniao);
            await _context.SaveChangesAsync();

            return reuniao;
        }

        private bool EventoExists(Guid id)
        {
            return _context.Notificacoes.Any(e => e.Id == id);
        }

    }
}

