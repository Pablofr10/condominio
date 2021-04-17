

using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;

namespace Condominio.Domain.Interfaces.Services
{
    public interface IPermissaoService
    {
        IEnumerable<PermissoesResponse> GetPermissoes();
        Task<bool> CriarPermissao(PermissoesRequest permissao);
        Task<bool> EditarPermissoes(PermissoesEditarRequest permissao);
    }
}