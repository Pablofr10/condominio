

using Condominio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Repository.Commom
{
    public class CondominioDbContext : IdentityDbContext
    {
        public virtual  DbSet<Usuario> Usuarios { get; set; }
        public virtual  DbSet<Imagem> Imagens { get; set; }
        public virtual  DbSet<Contato> Contatos { get; set; }
        public virtual  DbSet<UsuarioReserva> UsuarioReservas { get; set; }
        public virtual  DbSet<Reserva> Reservas { get; set; }
        public virtual  DbSet<Visitante> Visitantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
    }
}