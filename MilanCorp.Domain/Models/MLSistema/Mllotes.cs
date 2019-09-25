using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mllotes
    {
        public Mllotes()
        {
            MllotesEntregues = new HashSet<MllotesEntregues>();
        }

        public int CodLeilao { get; set; }
        public string Lote { get; set; }
        public int? LoteGrande { get; set; }
        public int CodBem { get; set; }
        public short TipoLote { get; set; }
        public string Titulo { get; set; }
        public string DescBasica { get; set; }
        public string DescComplementar { get; set; }
        public string DescDestacada { get; set; }
        public string ObsAdicional { get; set; }
        public bool Retirado { get; set; }
        public bool Sucata { get; set; }
        public double? Quantidade { get; set; }
        public string Unidade { get; set; }
        public decimal MinimoCia { get; set; }
        public decimal ValorMolicar { get; set; }
        public decimal AvalLeiloeiro { get; set; }
        public DateTime? DataMolicar { get; set; }
        public double IndiceDesv { get; set; }
        public byte? EstadoGeral { get; set; }
        public byte? Ipvastatus { get; set; }
        public short? Ipvaano { get; set; }
        public byte? Porte { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCondicional { get; set; }
        public decimal ValorVendaDm { get; set; }
        public decimal ValorCondicionalDm { get; set; }
        public int? CodFormaPgto { get; set; }
        public bool VendaCancelada { get; set; }
        public byte? MotivoCancelCod { get; set; }
        public string MotivoCancelDesc { get; set; }
        public int? QuemCancelou { get; set; }
        public decimal? ValorMaxAtingido { get; set; }
        public bool VendaConferida { get; set; }
        public int? Nvnumero { get; set; }
        public int? CodComprador { get; set; }
        public decimal? Comissao { get; set; }
        public decimal DespAdmin { get; set; }
        public decimal DespRemocao { get; set; }
        public decimal DespTransferencia { get; set; }
        public decimal DespEmpilhadeira { get; set; }
        public decimal DespAcessoria { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Nvusuario { get; set; }
        public DateTime? NvdataEmissao { get; set; }
        public string Nvip { get; set; }
        public int? QuantLeilao { get; set; }
        public string NovoLote { get; set; }
        public decimal? MaxAtingidoBk { get; set; }
        public double? Peso { get; set; }
        public byte? Parte { get; set; }
        public string Inventario { get; set; }
        public bool LoteOnline { get; set; }
        public decimal VendaImediataValor { get; set; }
        public string CodFipe { get; set; }
        public int? CodEndereco { get; set; }
        public string ObsAdicionalResumida { get; set; }
        public bool PrestacaoContasRealizada { get; set; }
        public bool? VendaOnline { get; set; }
        public bool NvalteracaoAutorizada { get; set; }

        public virtual Mlbens CodBemNavigation { get; set; }
        public virtual Mlcompradores CodCompradorNavigation { get; set; }
        public virtual MlcompradoresEnd CodEnderecoNavigation { get; set; }
        public virtual MlformaPagamento CodFormaPgtoNavigation { get; set; }
        public virtual Mlleiloes CodLeilaoNavigation { get; set; }
        public virtual ICollection<MllotesEntregues> MllotesEntregues { get; set; }
    }
}
