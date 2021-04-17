using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;

namespace Condominio.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponse>> BuscaUsuarios();

        Task<UsuarioResponse> BuscaUsuarioPorId(int id);

        Task<bool> AdicionaUsuario(UsuarioRequest usuario);

        Task<bool> AtualizaUsuario(int id, UsuarioRequest usuario);
    }
}