using System;

namespace MilanCorp.Domain
{
    public partial class MldocumentosVeic
    {
        public int CodBem { get; set; }
        public byte CodTipoDoc { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public byte? Status { get; set; }
        public byte? Posse { get; set; }
        public string Comentario { get; set; }

        public virtual Mlveiculos CodBemNavigation { get; set; }
    }
}
