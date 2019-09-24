

using MilanCorp.API.Dtos;
using MilanCorp.Domain.Models;

namespace MilanCorp.API.Interfaces
{
    public interface IAuthenticationService
    {
        UserLDAP Login(string userName, string password);

        UserDto CheckUserAD(string userName, string password);

    }
}
