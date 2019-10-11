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
    public class MaterialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetMaterial()
        {
            try
            {
                IQueryable<Material> query = _context.Materiais
               .Include(c => c.Upload)
               .Include(c => c.Usuario);

                return Ok(query);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost("cadastrarMaterial")]
        [AllowAnonymous]
        public async Task<ActionResult<Material>> PostEvento(List<Material> materiais)
        {
            try
            {
                if (materiais.Count < 1)
                {
                    return this.StatusCode(StatusCodes.Status400BadRequest, "Banco de Dados Falhou");
                }
                else
                {
                    foreach (var mat in materiais)
                    {
                        mat.Id = Guid.NewGuid();
                        _context.Add(mat);
                        await _context.SaveChangesAsync();
                    }
                }
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

    }
}
