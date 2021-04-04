using System.Text;
using Condominio.Domain.Dtos.Identity;
using Condominio.Repository.Commom;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Condominio.API.Dependencies
{
    public class IdentityDependecy
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependece(serviceProvider);
        }

        public static IConfiguration Configuration { get; set; }

        static readonly string chave = Configuration.GetSection("AppSettings:Token").Value;

        private static void RepositoryDependece(IServiceCollection serviceProvider)
        {
            IdentityBuilder builder = serviceProvider.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<CondominioDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            serviceProvider.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(chave)),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
        }
    }
}