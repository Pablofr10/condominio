using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Dtos.UsuarioRequest;

namespace Condominio.Application.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioResponse>> Get();
        Task<UsuarioResponse> Get(int id);
        Task<bool> PostUsuario(UsuarioRequest usuario);
        Task<bool> PutUsuario(int id, UsuarioRequest usuario);
    }
}