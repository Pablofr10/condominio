using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Condominio.Application.Exceptions;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace Condominio.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public AuthRepository(IConfiguration configuration, UserManager<User> userManager,
            SignInManager<User> signInManager, IMapper mapper, ILoggerManager logger)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserResponse> Registro(UserRequest usuario)
        {
            try
            {
                var user = _mapper.Map<User>(usuario);
                var result = await _userManager.CreateAsync(user, usuario.Password);

                var userToReturn = _mapper.Map<UserResponse>(user);

                if (!result.Succeeded)
                {
                    throw new LoginException($"Usuário não cadastrado {result.Errors}");
                }

                return userToReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao cadastrar usuário {ex.Message}");
            }
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest userLogin)
        {
            _logger.LogInfo("Verificando usuário");
            var user = await _userManager.FindByNameAsync(userLogin.UserName);

            if (user == null)
            {
                _logger.LogError("Usuário não existe");
                throw new LoginException("Usuário não existe");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

            if (result.Succeeded)
            {
                var userBanco =
                    await _userManager.Users.FirstOrDefaultAsync(u =>
                        u.NormalizedUserName == userLogin.UserName.ToUpper());

                var userRetornado = _mapper.Map<UserLoginResponse>(userBanco);

                userRetornado.Token = GenerateJwToken(userBanco).Result;
                _logger.LogInfo("Usuário logado com sucesso!");

                return userRetornado;
            }
            
            _logger.LogError("Erro ao realizar o login");
            throw new LoginException("Login não autorizado");
        }

        private async Task<string> GenerateJwToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}