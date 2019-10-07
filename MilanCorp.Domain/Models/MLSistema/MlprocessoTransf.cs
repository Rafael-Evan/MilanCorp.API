using System;

namespace MilanCorp.Domain
{
    public partial class MlprocessoTransf
    {
        public int Codigo { get; set; }
        public int CodBem { get; set; }
        public byte Acao { get; set; }
        public DateTime Data { get; set; }
        public string Comentario { get; set; }
        public int Usuario { get; set; }
        public bool Pendencia { get; set; }
        public int Solucao { get; set; }
        public DateTime? DataPendencia { get; set; }
        public byte? CodTipoDoc { get; set; }
        public string Mudancas { get; set; }
        public byte? QuemDeveResolver { get; set; }

        public virtual Mlveiculos CodBemNavigation { get; set; }
        public virtual Rbadm UsuarioNavigation { get; set; }
    }
}
