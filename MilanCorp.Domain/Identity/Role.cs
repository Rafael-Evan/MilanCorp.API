﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MilanCorp.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
