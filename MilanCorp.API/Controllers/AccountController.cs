using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MilanCorp.Domain.Interfaces;
using MilanCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService authService;
        private readonly IConfiguration _config;

        public AccountController(IAuthenticationService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string userName, string password)
        {
            userName = "rafael.evangelista";
            password = "Programador@10";

            var user = authService.Login(userName, password);
            if (null != user)
            {
                return Ok(new
                {
                    token = GenarateJwToken(user).Result,
                    //user = userToReturn

                });
            }
            else
            {
                return Unauthorized();
            }
        }


        private async Task<string> GenarateJwToken(UserLDAP user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
