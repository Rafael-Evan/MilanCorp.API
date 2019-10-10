using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Reuniao
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string departamento { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string sala { get; set; }
        public DateTime? data { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
