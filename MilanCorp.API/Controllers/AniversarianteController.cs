using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
            aniversariante.ativo = true;
            _context.Add(aniversariante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAniversariante", new { id = aniversariante.id }, aniversariante);
        }

        [HttpPost("ImportarAniversariantes"), DisableRequestSizeLimit]
        [AllowAnonymous]
        public async Task<ActionResult> ImportarAniversariantesAsync(IFormFile file)
        {
            var upload = new FileUpload();

            var fullPath = "";
            try
            {
                //foreach (var item in Request.Form.Files)
                //{
                    //var file = item;
                    var filename = Path.ChangeExtension(Guid.NewGuid().ToString(), ".xlsx");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resources", filename);
                    var folderName = Path.Combine("wwwroot/Resources/Aniversariantes");

                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    fullPath = Path.Combine(pathToSave, filename);
                    //var dbPath = Path.Combine(folderName, filename); 

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                //}

                FileInfo fileUp = new FileInfo(Path.Combine(fullPath));
                string FileName = fileUp.Name.Remove(fileUp.Name.Length - 5, 5);

                byte[] arquivo = System.IO.File.ReadAllBytes(fullPath);

                using (ExcelPackage package = new ExcelPackage(fileUp))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets["Aniversariantes"];
                    int totalRows = workSheet.Dimension.Rows;

                    var listaDeAniversariante = await _context.Aniversariantes.ToListAsync();

                    var ExcelList = new List<Aniversariante>();

                    for (int i = 2; i <= totalRows; i++)
                    {

                        ExcelList.Add(new Aniversariante
                        {
                            id = Guid.NewGuid(),
                            title = workSheet.Cells[i, 1].Value.ToString(),
                            start = Convert.ToDateTime(workSheet.Cells[i, 2].Value),
                            ativo = true
                        });
                    }

                    foreach (var aniversariante in listaDeAniversariante)
                    {
                        foreach (var itemExcel in ExcelList)
                        {
                            if (itemExcel.title.Equals(aniversariante.title) && itemExcel.start.Equals(aniversariante.start))
                            {
                                ExcelList.Remove(itemExcel);
                                break;
                            }
                        }
                    }
                    _context.Aniversariantes.AddRange(ExcelList);
                    _context.SaveChanges();
                }

                return Ok(upload.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
