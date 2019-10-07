using System;

namespace MilanCorp.Domain
{
    public partial class MllotesEntregues
    {
        public int Id { get; set; }
        public DateTime DataRetirada { get; set; }
        public int CodLeilao { get; set; }
        public string Lote { get; set; }
        public int UsuarioEntregou { get; set; }
        public string NomeRetirou { get; set; }
        public string Rgretirou { get; set; }
        public byte SituacaoVeiculo { get; set; }
        public string Obs { get; set; }
        public string ImageName { get; set; }
        public string Email { get; set; }

        public virtual Mllotes Mllotes { get; set; }
    }
}
