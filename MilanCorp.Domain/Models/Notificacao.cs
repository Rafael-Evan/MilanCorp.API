using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public DateTime Data { get; set; }
        public int Expirar { get; set; }
    }
}
