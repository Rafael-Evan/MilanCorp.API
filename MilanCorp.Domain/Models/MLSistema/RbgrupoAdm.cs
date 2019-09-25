using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class RbgrupoAdm
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodAplicacao { get; set; }

        public virtual Rbaplicacoes CodAplicacaoNavigation { get; set; }
    }
}
