using Microsoft.AspNetCore.Identity;
using MilanCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilanCorp.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public string Cargo { get; set; }
        public DateTime Data { get; set; }
        public bool UserAD { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<Material> Materiais { get; set; }
        public List<Reuniao> Reunioes { get; set; }
        public List<Ferias> Ferias { get; set; }
        public List<Recebimento> Recebimentos { get; set; }
    }
}
