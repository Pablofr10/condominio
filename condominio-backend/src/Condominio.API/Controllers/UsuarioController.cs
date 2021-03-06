using System;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await GetService<IUsuarioService>().BuscaUsuarios();

            if (usuarios != null)
            {
                return Ok(usuarios);
            }

            return BadRequest("Erro ao obter os usuários.");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await GetService<IUsuarioService>().BuscaUsuarioPorId(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }

            return BadRequest("Erro ao obter usuário.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequest usuario)
        {
            var isUsuarioCriado = await GetService<IUsuarioService>().AdicionaUsuario(usuario);
            
            if (isUsuarioCriado)
            {
                return Ok("Usuário criado!");
            }

            return BadRequest("Erro ao criar o usuário.");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, UsuarioRequest usuario)
        {
            var isUsuarioCriado = await GetService<IUsuarioService>().AtualizaUsuario(id, usuario);
            
            if (isUsuarioCriado)
            {
                return Ok("Usuario Editado com sucesso");
            }

            return BadRequest("Erro ao criar o usuário.");
        }
        
    }
}