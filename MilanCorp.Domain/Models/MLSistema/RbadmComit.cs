using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class RbadmComit
    {
        public int CodAdm { get; set; }
        public short CodComit { get; set; }

        public virtual Rbadm CodAdmNavigation { get; set; }
        public virtual Mlcomitentes CodComitNavigation { get; set; }
    }
}
