using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MilanCorp.Domain.Models
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public int lastModified { get; set; }

        [JsonIgnore]
        public virtual ICollection<Material> Materiais { get; set; }


    }
}
