using System.Threading.Tasks;
using Condominio.Domain.Dtos.UsuarioRequest;

namespace Condominio.Interface.Repository
{
    public interface IAuthRepository
    {
        Task<bool> Registro(AuthRequest model);
    }
}