using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class RblogsAdm
    {
        public int Codigo { get; set; }
        public string Acao { get; set; }
        public int CodAdm { get; set; }
        public DateTime Data { get; set; }
        public string Ip { get; set; }
        public int CodAplicacao { get; set; }
        public byte TipoLog { get; set; }
    }
}
