using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Rbadm
    {
        public Rbadm()
        {
            MlprocessoTransf = new HashSet<MlprocessoTransf>();
            RbadmComit = new HashSet<RbadmComit>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int CodAplicacao { get; set; }
        public byte UsuarioBloqueado { get; set; }
        public DateTime? DataBloqueio { get; set; }
        public string MotivoBloqueio { get; set; }
        public byte TipoUsuario { get; set; }

        public virtual Rbaplicacoes CodAplicacaoNavigation { get; set; }
        public virtual ICollection<MlprocessoTransf> MlprocessoTransf { get; set; }
        public virtual ICollection<RbadmComit> RbadmComit { get; set; }
    }
}
