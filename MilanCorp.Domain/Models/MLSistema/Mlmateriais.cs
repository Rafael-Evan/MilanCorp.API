using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlmateriais
    {
        public int Id { get; set; }
        public int? CodBem { get; set; }
        public short CodTipoBem { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Transportador { get; set; }
        public string Vistoriador { get; set; }
        public string Motorista { get; set; }
        public double? Quantidade { get; set; }
        public string Unidade { get; set; }
        public string CodMaterial { get; set; }
        public string Origem { get; set; }
        public string OrigemEst { get; set; }
        public bool IncluidoLeilao { get; set; }
        public double? Peso { get; set; }
        public int? Idcopia { get; set; }
        public string Mbbinventario { get; set; }
        public string Mbbqu { get; set; }
        public string MbbnumImo { get; set; }
        public DateTime? MbbdataImo { get; set; }
        public string Mbep { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal? ValorEstadiaNaVenda { get; set; }

        public virtual Mlbens Cod { get; set; }
    }
}
