using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mllocais
    {
        public Mllocais()
        {
            Mlbens = new HashSet<Mlbens>();
        }

        public short Codigo { get; set; }
        public string Apelido { get; set; }
        public string Endereco { get; set; }
        public bool? Ativo { get; set; }

        public virtual ICollection<Mlbens> Mlbens { get; set; }
    }
}
