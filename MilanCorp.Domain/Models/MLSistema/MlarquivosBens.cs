using System;

namespace MilanCorp.Domain
{
    public partial class MlarquivosBens
    {
        public int Codigo { get; set; }
        public int CodBem { get; set; }
        public string NomeArquivoCompleto { get; set; }
        public string NomeArquivoOriginal { get; set; }
        public string Pasta { get; set; }
        public DateTime Data { get; set; }
        public int? EnviadoPor { get; set; }
        public short TipoArquivo { get; set; }
        public int? TamanhoBytes { get; set; }
        public string Descricao { get; set; }
        public bool? Temporario { get; set; }
        public string AlteradoPor { get; set; }

        public virtual Mlbens CodBemNavigation { get; set; }
    }
}
