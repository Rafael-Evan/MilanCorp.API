using MilanCorp.Domain.Identity;
using MilanCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
