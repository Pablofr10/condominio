using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Interface.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            var usuario = await GetService<IAuthRepository>().Registro(user);
            
            if (usuario != null)
            {
                return Created("GetUser", usuario);
            }

            return BadRequest("Usuário não cadastrado");
        }
        
        [HttpPost("GetUser")]
        public async Task<IActionResult> Login(UserLoginRequest userLogin)
        {
            var usuario = await GetService<IAuthRepository>().Login(userLogin);
            
            if (usuario != null)
            {
                var token = Genera
                return Created("GetUser", usuario);
            }

            return BadRequest("Usuário não cadastrado");
        }
    }
}