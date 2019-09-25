using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlcoligados
    {
        public Mlcoligados()
        {
            Mlbens = new HashSet<Mlbens>();
        }

        public short Codigo { get; set; }
        public string Nome { get; set; }
        public short CodComit { get; set; }

        public virtual Mlcomitentes CodComitNavigation { get; set; }
        public virtual ICollection<Mlbens> Mlbens { get; set; }
    }
}
