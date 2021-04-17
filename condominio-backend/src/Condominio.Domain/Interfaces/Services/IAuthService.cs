using System.Threading.Tasks;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;

namespace Condominio.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserResponse> Registro(UserRequest usuario);
        Task<UserLoginResponse> Login(UserLoginRequest login);
        Task<UserLoginResponse> EsqueceuLogin(string email);
    }
}