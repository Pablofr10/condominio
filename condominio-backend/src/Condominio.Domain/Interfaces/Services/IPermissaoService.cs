

using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;

namespace Condominio.Domain.Interfaces.Services
{
    public interface IPermissaoService
    {
        IEnumerable<PermissoesResponse> GetPermissoes();
        Task<IEnumerable<UserRoleResponse>> GetPermissao(int id);
        Task<bool> CriarPermissao(PermissoesRequest permissao);
        Task<bool> EditarPermissoes(PermissoesEditarRequest permissao);
        Task<bool> EditarPermissoesUsuarios(List<UserRoleDto> rolesUsers, string roleId);
    }
}