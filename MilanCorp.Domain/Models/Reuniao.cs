using MilanCorp.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilanCorp.Domain.Models
{
    public class Reuniao
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string title { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string departamento { get; set; }
        public int sala { get; set; }
        public int local { get; set; }
        public DateTime? data { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public virtual User User { get; set; }

    }
}
