using System;

namespace MilanCorp.Domain
{
    public partial class MlboletosPortoSeg
    {
        public int Codigo { get; set; }
        public int CodBem { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataEnvio { get; set; }
        public DateTime? DataVencimento { get; set; }
        public byte Status { get; set; }
        public decimal? ValorPcv { get; set; }
        public DateTime DataImportacao { get; set; }
        public bool Pago { get; set; }

        public virtual Mlbens CodBemNavigation { get; set; }
    }
}
