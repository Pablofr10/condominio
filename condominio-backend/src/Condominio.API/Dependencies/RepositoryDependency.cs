using System;
using Condominio.API.Helpers;
using Condominio.Interface.Repository;
using Condominio.Repository.Repositories;
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
        }
    }
}