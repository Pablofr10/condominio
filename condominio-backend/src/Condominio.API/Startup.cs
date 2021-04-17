using System;
using System.Data.Common;
using System.IO;
using Condominio.API.Dependencies;
using Condominio.API.Helpers;
using Condominio.Application.Repository;
using Condominio.Infrastructure.Commom;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using Npgsql;

namespace Condominio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public DbConnection DdConnection => new NpgsqlConnection(Configuration.GetConnectionString("App"));
        public string TokenChave => Configuration.GetSection("AppSettings:Token").Value;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CondominioDbContext>(options =>
            {
                options.UseNpgsql(
                    DdConnection,
                    assembly => assembly.MigrationsAssembly(typeof(CondominioDbContext).Assembly.FullName));
            });

            IdentityDependecy.Register(services, TokenChave);

            RepositoryDependence.Register(services);

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy)); 
            }).AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddCors();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                
                
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Condominio.API", Version = "v1"});
                
                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Condominio.API v1"));
            }
            
            app.ConfigureExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origen => true)
                .AllowCredentials();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}