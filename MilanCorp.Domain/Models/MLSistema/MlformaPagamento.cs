using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class MlformaPagamento
    {
        public MlformaPagamento()
        {
            Mllotes = new HashSet<Mllotes>();
        }

        public int CodFormaPgto { get; set; }
        public int? CodComprador { get; set; }
        public byte? OpcaoPagamento { get; set; }
        public byte? ChequeTipo { get; set; }
        public string ChequeBanco { get; set; }
        public string ChequeAgencia { get; set; }
        public string ChequeConta { get; set; }
        public string ChequeNumero { get; set; }
        public string DepositoTipo { get; set; }
        public string DepositoConta { get; set; }
        public string DepositoOrigem { get; set; }
        public string DescricaoPagam { get; set; }
        public DateTime? DataDep { get; set; }
        public string NumeroDep { get; set; }
        public string AutenticacaoDep { get; set; }
        public string OrigiemDep { get; set; }
        public string DescricaoCc { get; set; }
        public string DescricaoComp { get; set; }

        public virtual Mlcompradores CodCompradorNavigation { get; set; }
        public virtual ICollection<Mllotes> Mllotes { get; set; }
    }
}
