using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Domain.Dtos;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class PermissaoController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;
        public PermissaoController(IServiceProvider serviceProvider, RoleManager<Role> roleManager) : base(
            serviceProvider)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetPermissoes()
        {
            var permicoes = GetService<IPermissaoService>().GetPermissoes();

            if (permicoes.Any()) return Ok(permicoes);

            return NoContent();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissao(int id)
        {
            var permissao = await GetService<IPermissaoService>().GetPermissao(id);

            if (permissao.Any()) return Ok(permissao);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CriaPermissao(PermissoesRequest role)
        {
            var isPermissaoCriada = await GetService<IPermissaoService>().CriarPermissao(role);

            if (isPermissaoCriada) return Ok("Permissao criada com sucesso");

            return BadRequest("Erro ao criar a permissão");
        }
        
        [HttpPut]
        public async Task<IActionResult> CriaPermissao(PermissoesEditarRequest role)
        {
            var isPermissaoEditada = await GetService<IPermissaoService>().EditarPermissoes(role);

            if (isPermissaoEditada) return Ok("Permissao editada com sucesso");

            return BadRequest("Erro ao editar a permissão");
        }
        
        [HttpPost]
        [Route("EditarPermissoes")]

        public async Task<IActionResult> EditarPermissoesUsuarios(List<UserRoleDto> role, string roleId)
        {
            var isPermissaoEditada = await GetService<IPermissaoService>().EditarPermissoesUsuarios(role, roleId);

            if (isPermissaoEditada) return Ok("Permissões editada com sucesso");

            return BadRequest("Erro ao editar a permissão");
        }
    }
}