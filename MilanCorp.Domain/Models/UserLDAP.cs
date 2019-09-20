using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class UserLDAP : IdentityUser<int>
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        // other properties
    }
}
