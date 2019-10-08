using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class EventoLeilao
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public DateTime? start { get; set; }
        public string nomeDoComitente { get; set; }
        public string observacao { get; set; }
        public string endereco { get; set; }
        public string tipoDeLeilao { get; set; }
    }
}
