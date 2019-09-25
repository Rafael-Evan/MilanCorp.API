using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class RblogBloqueios
    {
        public int Id { get; set; }
        public int CodUsuario { get; set; }
        public string Pagina { get; set; }
        public string Acesso { get; set; }
        public DateTime? Data { get; set; }
    }
}
