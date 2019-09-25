using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class MlcompradoresEnd
    {
        public MlcompradoresEnd()
        {
            Mllotes = new HashSet<Mllotes>();
        }

        public int Codigo { get; set; }
        public int CodComprador { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CodCidade { get; set; }
        public string Uf { get; set; }
        public string Titulo { get; set; }
        public bool Oculto { get; set; }
        public bool ModeloAntigo { get; set; }
        public DateTime? DataRegistro { get; set; }

        public virtual Mlcompradores CodCompradorNavigation { get; set; }
        public virtual ICollection<Mllotes> Mllotes { get; set; }
    }
}
