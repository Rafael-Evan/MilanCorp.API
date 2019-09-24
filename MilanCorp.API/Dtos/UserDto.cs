using System;

namespace MilanCorp.API.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserAD { get; set; }
    }
}
