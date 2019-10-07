using System;

namespace MilanCorp.Domain
{
    public partial class MlremocoesVeic
    {
        public int Codigo { get; set; }
        public DateTime? DataPedidoRemocao { get; set; }
        public DateTime? DataPermanenciaJuridica { get; set; }
        public string DataPedidoAutorRemocao { get; set; }
        public DateTime? DataAutorRemocao { get; set; }
        public DateTime? DataAutorPagEstadias { get; set; }
        public string Assessoria { get; set; }
        public string VeiculoPlaca { get; set; }
        public string VeiculoChassi { get; set; }
        public string VeiculoMarca { get; set; }
        public string VeiculoModelo { get; set; }
        public string VeiculoAno { get; set; }
        public string LocalApreensao { get; set; }
        public string LocalApreensaoCidade { get; set; }
        public string LocalApreensaoUf { get; set; }
        public string LocalApreensaoContato { get; set; }
        public string LocalApoio { get; set; }
        public string LocalApoioCidade { get; set; }
        public string LocalApoioUf { get; set; }
        public string LocalApoioContato { get; set; }
        public string LocalApoioTipo { get; set; }
        public string Transportador { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataEntradaMilan { get; set; }
        public byte? Status { get; set; }
        public decimal? EstadiaValorDia { get; set; }
        public DateTime? EstadiaAte { get; set; }
        public bool? EstadiaReembolsavel { get; set; }
        public short? EstadiaCarencia { get; set; }
        public decimal? GuinchoValor { get; set; }
        public bool? GuinchoReembolsavel { get; set; }
        public decimal? Transporte { get; set; }
        public bool? TransporteReembolsavel { get; set; }
        public int CodColigado { get; set; }
        public DateTime? DataRegistro { get; set; }
        public int? CodVeic { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public decimal? GuinchoApreensaoValor { get; set; }
        public bool? GuinchoApreensaoReemb { get; set; }
        public string EstadiaCobranca { get; set; }
        public string EstadiaBoleto { get; set; }
        public DateTime? EstadiaVencimento { get; set; }
        public string TransporteCobranca { get; set; }
        public string TransporteBoleto { get; set; }
        public DateTime? TransporteVencimento { get; set; }
        public string GuinchoCobranca { get; set; }
        public string GuinchoBoleto { get; set; }
        public DateTime? GuinchoVencimento { get; set; }
        public string GuinchoApreensaoCobranca { get; set; }
        public string GuinchoApreensaoBoleto { get; set; }
        public DateTime? GuinchoApreensaoVencimento { get; set; }
        public decimal? MunckValor { get; set; }
        public bool? MunckReemb { get; set; }
        public string MunckCobranca { get; set; }
        public string MunckBoleto { get; set; }
        public DateTime? MunckVencimento { get; set; }

        public virtual Mlveiculos CodVeicNavigation { get; set; }
    }
}
