﻿namespace MilanCorp.Domain
{
    public partial class RbacessosAdm
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Pagina { get; set; }
        public int CodAplicacao { get; set; }

        public virtual Rbaplicacoes CodAplicacaoNavigation { get; set; }
    }
}
