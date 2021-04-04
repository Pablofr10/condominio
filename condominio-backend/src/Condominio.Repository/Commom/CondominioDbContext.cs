using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Repository.Commom
{
    public sealed class CondominioDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            UserRoleMap(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public CondominioDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public CondominioDbContext(DbContextOptions<CondominioDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        
        private static void UserRoleMap(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<UserRole>(userRole =>
                    {
                        userRole.HasOne(ur => ur.Role)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();
        
                        userRole.HasOne(ur => ur.User)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.UserId)
                            .IsRequired();
                        
                    });
                }
    }
}