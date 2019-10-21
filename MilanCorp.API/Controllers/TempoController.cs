using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanCorp.Repository;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TempoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetClima()
        {
            try
            {
                string url = "http://apiadvisor.climatempo.com.br/api/v1/weather/locale/3477/current?token=866474fc3c51b2f4229db9d8f11648de";
                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);

                return Ok(json);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
    }
}
