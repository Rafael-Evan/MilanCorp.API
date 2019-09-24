using Microsoft.AspNetCore.Identity;

namespace MilanCorp.Domain.Models
{
    public class UserLDAP : IdentityUser<int>
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // other properties
    }
}
