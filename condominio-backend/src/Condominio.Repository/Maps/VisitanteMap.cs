using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class VisitanteMap : BaseDomainMap<Visitante>
    {
        public VisitanteMap() : base("tb_visitante"){}

        public override void Configure(EntityTypeBuilder<Visitante> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Confirmado).HasColumnName("confirmado").IsRequired();
            
            builder.HasMany(x => x.Usuarios)
                .WithMany(x => x.Visitantes)
                .UsingEntity<UsuarioVisitante>(
                    x => x.HasOne(f => f.Usuario).WithMany().HasForeignKey(x => x.IdUsuario),
                    x => x.HasOne(f => f.Visitante).WithMany().HasForeignKey(f => f.IdVisitante),
                    x =>
                    {
                        x.ToTable("tb_usuario_visitante");

                        x.HasKey(f => new {f.IdUsuario, f.IdVisitante});

                        x.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
                        x.Property(x => x.DataVisita).HasColumnName("data_visita").IsRequired();
                        x.Property(x => x.IdUsuario).HasColumnName("id_usuario").IsRequired();
                        x.Property(x => x.IdVisitante).HasColumnName("id_visitante").IsRequired();
                    }
                );
        }
    }
}