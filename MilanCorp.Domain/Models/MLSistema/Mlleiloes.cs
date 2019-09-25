using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlleiloes
    {
        public Mlleiloes()
        {
            Mllotes = new HashSet<Mllotes>();
        }

        public int CodLeilao { get; set; }
        public int? CodLeilaoWeb { get; set; }
        public DateTime DataInicio { get; set; }
        public string Local { get; set; }
        public string Titulo { get; set; }
        public string PastaFotos { get; set; }
        public string NumeroLeilao { get; set; }
        public string LotesOnline { get; set; }
        public string MbbaprovadorPrecos { get; set; }
        public bool LeilaoImoveis { get; set; }
        public string NumeroLeilaoLivro { get; set; }
        public byte PrestacaoContasRealizada { get; set; }
        public int? CodLeilaoWebTest { get; set; }
        public bool? PrestacaoContasRealizada2 { get; set; }

        public virtual ICollection<Mllotes> Mllotes { get; set; }
    }
}
