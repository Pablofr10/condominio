using System;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracaoController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;

        public AdministracaoController(IServiceProvider serviceProvider, RoleManager<Role> roleManager) : base(
            serviceProvider)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetPermicoes()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CriaPermissao(Role role)
        {
            Role criarPermissao = new Role
            {
                Name = role.Name
            };

            IdentityResult resul = await _roleManager.CreateAsync(criarPermissao);

            if (resul.Succeeded)
            {
                return Ok("Permissao criada com sucesso");
            }

            return BadRequest("Erro ao criar a permissão");
        }
    }
}