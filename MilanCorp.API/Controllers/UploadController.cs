using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            try
            {
                foreach (var item in Request.Form.Files)
                {
                    foreach (var NomeDaPasta in Request.Form.Keys)
                    {
                        var file = item;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resources", file.FileName);
                        var folderName = Path.Combine("wwwroot/Resources", NomeDaPasta);
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);

                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);

                                upload.Id = new Guid();
                                upload.name = item.FileName;

                                _context.Add(upload);
                                _context.SaveChangesAsync();
                            }
                        }
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Upload(ICollection<IFormFile> files, string name)
        //{
        //    try
        //    {
        //        var result = new List<FileUploadResult>();
        //        foreach (var file in files)
        //        {
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resources", file.FileName);
        //            var stream = new FileStream(path, FileMode.Create);
        //            file.CopyToAsync(stream);
        //            result.Add(new FileUploadResult() { Name = file.FileName, Length = file.Length });
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
