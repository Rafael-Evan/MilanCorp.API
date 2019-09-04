using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Evento
    {
        public Guid Id { get; set; }
        public String title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool finished { get; set; }
    }
}
