using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Collections.Generic;
using System.IO;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UploadController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost, DisableRequestSizeLimit]
        [AllowAnonymous]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            var upload = new FileUpload();
            var ano = DateTime.Now.Year;
            var NF_fileNameOfExtension = "";
            var TERMO_NF_fileNameOfExtension = "";
            try
            {
                foreach (var item in Request.Form.Files)
                {
                    foreach (var NomeDaPasta in Request.Form.Keys)
                    {
                        var file = item;
                        var filename = Path.ChangeExtension(Guid.NewGuid().ToString(), ".pdf");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resources", filename);
                        var folderName = Path.Combine("wwwroot/Resources", NomeDaPasta + "/" + ano);

                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }

                        if (file.Length > 0)
                        {
                            var verificarArquivo = file.FileName.Remove(file.FileName.Length - 4, 4);
                            if (verificarArquivo == "ArquivoNFe")
                            {
                                filename = "NF_" + filename;
                                NF_fileNameOfExtension = filename.Remove(filename.Length - 4, 4);
                            }
                            else
                            {
                                filename = "Termo_" + filename;
                                TERMO_NF_fileNameOfExtension = filename.Remove(filename.Length - 4, 4);
                            }

                            var fullPath = Path.Combine(pathToSave, filename);
                            var dbPath = Path.Combine(folderName, filename);

                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);

                                upload.nomeDaNota = NF_fileNameOfExtension;
                                upload.termoDeAceite = TERMO_NF_fileNameOfExtension;
                                

                                if (upload.termoDeAceite != "" && upload.nomeDaNota != "")
                                {
                                    upload.Id = new Guid();
                                    upload.type = Path.GetExtension(filename);
                                    upload.pasta = NomeDaPasta;
                                    upload.ano = ano;
                                    upload.data = DateTime.Now;
                                    _context.Add(upload);
                                    _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                return Ok(upload.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
