using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MilanCorp.API.Dtos;
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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context,
                              IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.UserName);

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

        [HttpPost("Id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsuarioId(UserLoginDto userLogin)
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

        [HttpPost("UserName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPorUserName(UserLoginDto userLogin)
        {
            try
            {
                IQueryable<User> query = _context.Users
              .Include(c => c.Materiais)
              .Include(c => c.UserRoles);

                query = query.Where(c => c.UserName == userLogin.UserName);

                return Ok(query);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<User> GetUserById(int userId)
        {
                IQueryable<User> query = _context.Users
               .Include(c => c.Materiais)
               .Include(c => c.UserRoles);

                query = query.Where(c => c.Id == userId);

                return await query.FirstOrDefaultAsync();
           
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<User[]> GetUser(int userId)
        {
            IQueryable<User> query = _context.Users
                .Include(c => c.Materiais)
                .Include(c => c.UserRoles);

            return await query.ToArrayAsync();

        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult> GetUser()
        //{
        //    try
        //    {
        //        var results = await _context.Users.ToListAsync();

        //        return Ok(results);
        //    }
        //    catch (Exception)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
        //    }
        //}

        [HttpPost("Register")]
        [AllowAnonymous]
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
