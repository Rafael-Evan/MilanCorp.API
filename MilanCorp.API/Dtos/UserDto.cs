using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanCorp.API.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public DateTime Data { get; set; }
        public string Password { get; set; }
    }
}
