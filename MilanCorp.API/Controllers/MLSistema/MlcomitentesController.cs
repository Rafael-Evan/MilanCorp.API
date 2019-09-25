using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain;
using MilanCorp.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers.MLSistema
{
    [Route("api/[controller]")]
    [ApiController]
    public class MlcomitentesController : ControllerBase
    {
        private readonly MLSistemaContext _context;

        public MlcomitentesController(MLSistemaContext context)
        {
            _context = context;
        }

        // GET: api/Mlcomitentes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Mlcomitentes>>> GetMlcomitentes()
        {
            return await _context.Mlcomitentes.ToListAsync();
        }

        // GET: api/Mlcomitentes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Mlcomitentes>> GetMlcomitentes(short id)
        {
            var mlcomitentes = await _context.Mlcomitentes.FindAsync(id);

            if (mlcomitentes == null)
            {
                return NotFound();
            }

            return mlcomitentes;
        }

        private bool MlcomitentesExists(short id)
        {
            return _context.Mlcomitentes.Any(e => e.Codigo == id);
        }
    }
}
