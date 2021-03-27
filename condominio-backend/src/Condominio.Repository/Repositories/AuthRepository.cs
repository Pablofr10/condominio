

using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Interface.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Condominio.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signIn;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration,
                                UserManager<User> userManager,
                                SignInManager<User> signIn,
                                IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signIn = signIn;
            _mapper = mapper;
        }

        public Task<bool> Registro(UserRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}