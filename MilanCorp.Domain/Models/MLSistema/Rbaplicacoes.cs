using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Rbaplicacoes
    {
        public Rbaplicacoes()
        {
            RbacessosAdm = new HashSet<RbacessosAdm>();
            Rbadm = new HashSet<Rbadm>();
            RbgrupoAdm = new HashSet<RbgrupoAdm>();
        }

        public int CodAplicacao { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<RbacessosAdm> RbacessosAdm { get; set; }
        public virtual ICollection<Rbadm> Rbadm { get; set; }
        public virtual ICollection<RbgrupoAdm> RbgrupoAdm { get; set; }
    }
}
