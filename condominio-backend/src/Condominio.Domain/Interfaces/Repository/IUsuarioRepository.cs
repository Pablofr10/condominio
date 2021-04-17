using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
    }
}