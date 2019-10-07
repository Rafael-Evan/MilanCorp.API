using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class MltiposBens
    {
        public MltiposBens()
        {
            Mlbens = new HashSet<Mlbens>();
        }

        public short Codigo { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Mlbens> Mlbens { get; set; }
    }
}
