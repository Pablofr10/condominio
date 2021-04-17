using System;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Interfaces.Repository;
using Condominio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(UserResponse usuario)
        {
            return Ok(usuario);
        }
        
        [HttpPost("Cadastrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastrar(UserRequest user)
        {
            var usuario = await GetService<IAuthService>().Registro(user);
            
            if (usuario != null)
            {
                return Created("GetUser", usuario);
            }

            return BadRequest("Usuário não cadastrado");
        }
        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginRequest userLogin)
        {
            UserLoginResponse user = await GetService<IAuthService>().Login(userLogin);
            
            if (user == null)
            {
                return BadRequest("Erro ao relizar login");
            }

            return Ok(user);
        }
        
        [HttpPost("RecuperarSenha")]
        [AllowAnonymous]
        public async Task<IActionResult> RecuperarLogin(string email)
        {
            UserLoginResponse user = await GetService<IAuthService>().EsqueceuLogin(enail);
            
            if (user == null)
            {
                return BadRequest("Erro ao relizar login");
            }

            return Ok(user);
        }
    }
}