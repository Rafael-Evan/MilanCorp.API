using System;

namespace MilanCorp.Domain
{
    public partial class MldespesasReembolsos
    {
        public int Codigo { get; set; }
        public decimal Valor { get; set; }
        public short Comitente { get; set; }
        public string DescricaoDespesa { get; set; }
        public DateTime DataDespesa { get; set; }
        public bool? Reembolsavel { get; set; }
        public bool Reembolsado { get; set; }
        public DateTime? DataReembolso { get; set; }
        public string DescricaoReembolso { get; set; }
        public DateTime RegistroDespesa { get; set; }
        public DateTime? RegistroReembolso { get; set; }
        public int? UsuarioReembolso { get; set; }
        public DateTime? AlteracaoDespesa { get; set; }
        public short? Tipodespesa { get; set; }
        public string InfoBem { get; set; }

        public virtual Mlcomitentes ComitenteNavigation { get; set; }
    }
}
