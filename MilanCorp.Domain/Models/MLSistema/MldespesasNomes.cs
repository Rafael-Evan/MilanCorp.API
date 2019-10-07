using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class MldespesasNomes
    {
        public MldespesasNomes()
        {
            MldespesasBem = new HashSet<MldespesasBem>();
        }

        public short Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<MldespesasBem> MldespesasBem { get; set; }
    }
}
