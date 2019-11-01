using MilanCorp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Recebimento
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Remetente { get; set; }
        public string NumeroDeRastreamento { get; set; }
        public string Quantidade { get; set; }
        public DateTime DataDoRecebimento { get; set; }
        public string RecebidoPor { get; set; }
        public string Status { get; set; }
        public virtual User User { get; set; }
    }
}
