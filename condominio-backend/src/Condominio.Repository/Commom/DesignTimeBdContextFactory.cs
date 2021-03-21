using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Condominio.Repository.Commom
{
    public class DesignTimeBdContextFactory : IDesignTimeDbContextFactory<CondominioDbContext>
    {
        public CondominioDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var fileName = Directory.GetCurrentDirectory() + $"/../Condominio.API/appsettings.Development.json";

            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();

            var connectionString = configuration.GetConnectionString("App");

            var builder = new DbContextOptionsBuilder<CondominioDbContext>();

            builder.UseNpgsql(connectionString);

            return new CondominioDbContext(builder.Options);
        }
    }
}