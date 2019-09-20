

using MilanCorp.Domain.Models;

namespace MilanCorp.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        UserLDAP Login(string userName, string password);
    }
}
