using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MilanCorp.API.Dtos;
using MilanCorp.API.Interfaces;
using MilanCorp.Domain.Identity;
using MilanCorp.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;

        public UserController(ApplicationDbContext context,
                              IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IAuthenticationService authService)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet("ListarTodosUsuarios")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var results = await _context.Users.ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.UserName);

                if (user == null)
                {
                    var currentUser = _authService.CheckUserAD(userLogin.UserName, userLogin.Password);

                    await Register(currentUser);

                    if (currentUser != null)
                    {
                        return await Login(userLogin);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }

                if (user.UserAD == true)
                {
                    return await LoginAD(userLogin);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == userLogin.UserName.ToUpper());

                    var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                    return Ok(new
                    {
                        token = GenarateJwToken(appUser).Result,
                        user = userToReturn

                    });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou{ex.Message}");
            }

        }

        [HttpPost("LoginAD")]
        public async Task<IActionResult> LoginAD(UserLoginDto userLogin)
        {
            try
            {
                var user = _authService.Login(userLogin.UserName, userLogin.Password);
                if (null != user)
                {
                    var userDB = await _userManager.FindByNameAsync(userLogin.UserName);

                    var appUser = await _userManager.Users
                            .FirstOrDefaultAsync(u => u.NormalizedUserName == userLogin.UserName.ToUpper());

                    var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                    return Ok(new
                    {

                        token = GenarateJwToken(userDB).Result,
                        user = userToReturn

                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou{ex.Message}");
            }
        }


        [HttpGet("FullName/{id}")]
        public async Task<ActionResult> GetFullName(int id)
        {
            try
            {
                var query = _context.Users;

                var fullName = from user in query
                               where user.Id == id
                               select user.FullName;

                return Ok(fullName);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost("Id")]
        public async Task<IActionResult> GetUserId(UserLoginDto userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.UserName);

                return Ok(user.Id);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarUserPorId(int Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id.ToString());

                return Ok(user);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost("VerificarAcessos")]
        public async Task<IActionResult> VerificarAcessosUsuario(UserLoginDto userLogin)
        {
            try
            {
                var query = _context.Users;

                var roleId = from user in query
                             where user.UserName == userLogin.UserName
                             select user.UserRoles;

                return Ok(roleId);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            try
            {
                userDto.Data = DateTime.UtcNow;
                var user = _mapper.Map<User>(userDto);

                user.UserName = user.UserName;

                var result = await _userManager.CreateAsync(user, userDto.Password);

                var userToReturn = _mapper.Map<UserDto>(user);

                if (result.Succeeded)
                {
                    var userRole = new UserRole();
                    userRole.UserId = user.Id;
                    userRole.RoleId = 2;
                    _context.Add(userRole);
                    _context.SaveChanges();

                    return Created("GetUser", userToReturn);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou{ex.Message}");
            }
        }

        private async Task<string> GenarateJwToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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
