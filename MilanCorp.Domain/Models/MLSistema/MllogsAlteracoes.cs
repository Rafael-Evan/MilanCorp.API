using System;

namespace MilanCorp.Domain
{
    public partial class MllogsAlteracoes
    {
        public int Codigo { get; set; }
        public string Tabela { get; set; }
        public string ChavesValores { get; set; }
        public string ChavesNomes { get; set; }
        public byte? ComandoCod { get; set; }
        public string CampoAlterado { get; set; }
        public string CampoValorAnterior { get; set; }
        public string CampoValorNovo { get; set; }
        public DateTime? Data { get; set; }
        public int? CodUsuario { get; set; }
        public string Ip { get; set; }
    }
}
