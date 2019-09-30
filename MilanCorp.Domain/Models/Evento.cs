using System;

namespace MilanCorp.Domain.Models
{
    public class Evento
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public bool? finished { get; set; }
        public  string leilao { get; set; }
        public string  nomeDoComitente { get; set; }
        public string observacao { get; set; }
        public string endereco { get; set; }
        public string tipoDeLeilao { get; set; }
    }
}
