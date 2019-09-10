using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MilanCorp.Domain.Models
{
    public class File
    {
        public ICollection<IFormFile> Files { get; set; }
    }
}
