using Condominio.API.Helpers;
using Condominio.Application.Services;
using Condominio.Domain.Interfaces.Repository;
using Condominio.Domain.Interfaces.Services;
using Condominio.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Condominio.API.Dependencies
{
    public class RepositoryDependence
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependecy(serviceProvider);
        }

        private static void RepositoryDependecy(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceProvider.AddScoped<IAuthRepository, AuthRepository>();
            serviceProvider.AddSingleton<ILoggerManager, LoggerManager>();
            serviceProvider.AddSingleton<IUsuarioService, UsuarioService>();
            serviceProvider.AddSingleton<IAuthRepository, AuthRepository>();
        }
    }
}