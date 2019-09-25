using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class MldespesasBem
    {
        public int Codigo { get; set; }
        public int CodBem { get; set; }
        public short CodNomeDespesa { get; set; }
        public decimal Valor { get; set; }
        public string NomePrestadorNf { get; set; }
        public DateTime? DataVencimentoNf { get; set; }
        public string Observacoes { get; set; }
        public byte TipoReembolso { get; set; }
        public string NumNf { get; set; }
        public DateTime? DataRegistro { get; set; }
        public bool Reembolsado { get; set; }
        public bool ConferidoFinanc { get; set; }

        public virtual Mlbens CodBemNavigation { get; set; }
        public virtual MldespesasNomes CodNomeDespesaNavigation { get; set; }
    }
}
