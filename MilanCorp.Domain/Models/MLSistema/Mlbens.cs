using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlbens
    {
        public Mlbens()
        {
            MlarquivosBens = new HashSet<MlarquivosBens>();
            MlboletosPortoSeg = new HashSet<MlboletosPortoSeg>();
            MldespesasBem = new HashSet<MldespesasBem>();
            Mllotes = new HashSet<Mllotes>();
            Mlmateriais = new HashSet<Mlmateriais>();
        }

        public int Codigo { get; set; }
        public short TipoBem { get; set; }
        public short CodColigado { get; set; }
        public short Local { get; set; }
        public string NomeFoto { get; set; }
        public string CaminhoFotoAnt { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataRegistro { get; set; }
        public DateTime? DataSaida { get; set; }
        public byte Situacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public short TotalFotos { get; set; }
        public int? SvId { get; set; }
        public bool LiberadoLeilao { get; set; }

        public virtual Mlcoligados CodColigadoNavigation { get; set; }
        public virtual Mllocais LocalNavigation { get; set; }
        public virtual MltiposBens TipoBemNavigation { get; set; }
        public virtual ICollection<MlarquivosBens> MlarquivosBens { get; set; }
        public virtual ICollection<MlboletosPortoSeg> MlboletosPortoSeg { get; set; }
        public virtual ICollection<MldespesasBem> MldespesasBem { get; set; }
        public virtual ICollection<Mllotes> Mllotes { get; set; }
        public virtual ICollection<Mlmateriais> Mlmateriais { get; set; }
    }
}
