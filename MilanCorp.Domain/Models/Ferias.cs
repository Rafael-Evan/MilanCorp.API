using MilanCorp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Ferias
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string NomeDoFuncionario { get; set; }
        public string Ramal { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeDeDias { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public int Expirar { get; set; }
        public virtual User User { get; set; }
    }
}
