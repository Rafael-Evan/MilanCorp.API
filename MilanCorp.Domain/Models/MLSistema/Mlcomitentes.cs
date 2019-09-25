using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlcomitentes
    {
        public Mlcomitentes()
        {
            Mlcoligados = new HashSet<Mlcoligados>();
            MldespesasReembolsos = new HashSet<MldespesasReembolsos>();
            RbadmComit = new HashSet<RbadmComit>();
        }

        public short Codigo { get; set; }
        public string Nome { get; set; }
        public string DirComit { get; set; }
        public bool? Ativo { get; set; }
        public byte? TipoComit { get; set; }
        public string Obsloteamento { get; set; }
        public decimal? DespRemocao { get; set; }
        public decimal? DespAcessoria { get; set; }
        public bool EstadiaNaPc { get; set; }
        public short? EstadiaCarencia { get; set; }
        public decimal? EstadiaValorMoto { get; set; }
        public decimal? EstadiaValorVeicLeve { get; set; }
        public decimal? EstadiaValorVeicPesado { get; set; }
        public decimal? EstadiaValorMaterial { get; set; }

        public virtual ICollection<Mlcoligados> Mlcoligados { get; set; }
        public virtual ICollection<MldespesasReembolsos> MldespesasReembolsos { get; set; }
        public virtual ICollection<RbadmComit> RbadmComit { get; set; }
    }
}
