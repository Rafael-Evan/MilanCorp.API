using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
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
                var results = await _context.Materiais.ToListAsync();

                return Ok(results);
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
                foreach (var mat in materiais)
                {
                    mat.Id = new Guid();
                    _context.Add(mat);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
           
        }

        [HttpPost("upload")]
        [AllowAnonymous]
        public async Task<ActionResult> upload(ICollection<IFormFile> files)
        {

            //var nomedoArquivo = Guid.NewGuid().ToString() + ".png";
            //var pasta = DateTime.Now.Year;
            //if (files == null)
            //    return Content("file not selected");

            //var verificarPasta = Path.Combine(
            //            Directory.GetCurrentDirectory(), "Fotos/CadastroMilanLeiloes/" + pasta);

            //if (!Directory.Exists(verificarPasta))
            //{
            //    //Criamos um com o nome folder
            //    Directory.CreateDirectory(verificarPasta);

            //}
            ////var path = Path.Combine(
            ////           Directory.GetCurrentDirectory(), "Fotos/CadastroMilanLeiloes/" + pasta,
            ////           files.FileName);

            //var path = Path.Combine(
            //           Directory.GetCurrentDirectory(), "Fotos/CadastroMilanLeiloes/" + pasta,
            //           nomedoArquivo);
            try
            {
                var file = Request.Form;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave =  Path.Combine(Directory.GetCurrentDirectory(), folderName);

                //if(file.Length > 0)
                //{
                //    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                //    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                //    using(var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //}

                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }
    }
}
