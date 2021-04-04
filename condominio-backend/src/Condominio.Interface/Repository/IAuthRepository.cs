using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;

namespace Condominio.Interface.Repository
{
    public interface IAuthRepository
    {
        Task<UserResponse> Registro(UserRequest usuario);
        Task<UserLoginResponse> Login(UserLoginRequest login);
    }
}