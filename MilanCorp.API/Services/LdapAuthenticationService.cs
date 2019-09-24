using Microsoft.Extensions.Options;
using MilanCorp.API.Dtos;
using MilanCorp.API.Interfaces;
using MilanCorp.API.Utils;
using MilanCorp.Domain.Models;
using MilanCorp.Repository;
using System;
using System.DirectoryServices;

namespace MilanCorp.API.Services
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private const string DisplayNameAttribute = "DisplayName";
        private const string SAMAccountNameAttribute = "SAMAccountName";

        private readonly LdapConfig config;
        private readonly ApplicationDbContext _context;

        public LdapAuthenticationService(IOptions<LdapConfig> config, ApplicationDbContext context)
        {
            this.config = config.Value;
            this._context = context;
        }

        public UserDto CheckUserAD(string userName, string password)
        {
            string propUsername = "samaccountname";
            string propFirstName = "givenName";
            string propLastName = "sn";
            string propMail = "mail";

            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(config.Path, config.UserDomainName + "\\" + userName, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                        searcher.PropertiesToLoad.Add(propUsername);
                        searcher.PropertiesToLoad.Add(propFirstName);
                        searcher.PropertiesToLoad.Add(propLastName);
                        searcher.PropertiesToLoad.Add(propMail);
                        var result = searcher.FindOne();
                        if (result != null)
                        {
                            var newUser = new UserDto();
                            newUser.UserName = result.Properties[propUsername][0].ToString();
                            newUser.FullName = result.Properties[propFirstName][0].ToString();
                            newUser.Email = "";
                            if (result.Properties.Contains(propLastName))
                            {
                                newUser.FullName = result.Properties[propFirstName][0].ToString() + " " + result.Properties[propLastName][0].ToString();
                            }
                            if (result.Properties.Contains(propMail))
                            {
                                newUser.Email = result.Properties[propMail][0].ToString();
                            }

                            newUser.Password = GerarHash.GerarCodigo();
                            newUser.Data = DateTime.UtcNow;
                            newUser.UserAD = true;

                            return new UserDto
                            {
                                UserName = newUser.UserName,
                                FullName = newUser.FullName,
                                Email = newUser.Email,
                                Password = newUser.Password,
                                Data = newUser.Data,
                                UserAD = newUser.UserAD
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if we get an error, it means we have a login failure.
                // Log specific exception
            }
            return null;
        }

        public UserLDAP Login(string userName, string password)
        {
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(config.Path, config.UserDomainName + "\\" + userName, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                        searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                        searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);
                        var result = searcher.FindOne();
                        if (result != null)
                        {
                            var displayName = result.Properties[DisplayNameAttribute];
                            var samAccountName = result.Properties[SAMAccountNameAttribute];

                            return new UserLDAP
                            {
                                DisplayName = displayName == null || displayName.Count <= 0 ? null : displayName[0].ToString(),
                                UserName = samAccountName == null || samAccountName.Count <= 0 ? null : samAccountName[0].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if we get an error, it means we have a login failure.
                // Log specific exception
            }
            return null;
        }

    }
}
