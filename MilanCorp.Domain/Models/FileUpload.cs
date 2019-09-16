using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MilanCorp.Domain.Models
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string nomeDaNota { get; set; }
        public string termoDeAceite { get; set; }
        public string pasta { get; set; }
        public int ano { get; set; }
        public DateTime data { get; set; }
        public string type { get; set; }
        public List<Material> Materiais { get; set; }

    }
}
