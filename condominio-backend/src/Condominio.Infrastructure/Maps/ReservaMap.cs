

using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Maps
{
    public class ReservaMap : BaseDomainMap<Reserva>
    {
        public ReservaMap() : base("tb_reserva"){}

        public override void Configure(EntityTypeBuilder<Reserva> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Local).HasColumnName("local").HasMaxLength(50).IsRequired();
            builder.Property(x => x.DataReserva).HasColumnName("data_reserva").IsRequired();
            builder.Property(x => x.HoraInicial).HasColumnName("hora_inicial").IsRequired();
            builder.Property(x => x.HoraFinal).HasColumnName("hora_final").IsRequired();
            builder.Property(x => x.QuantidadeConvidados).HasColumnName("quantidade_convidados").IsRequired();
            builder.Property(x => x.Situacao).HasColumnName("situacao").IsRequired();

            builder.HasMany(x => x.Usuarios)
                .WithMany(x => x.Reservas)
                .UsingEntity<UsuarioReserva>(
                    x => x.HasOne(f => f.Usuario).WithMany().HasForeignKey(x => x.IdUsuario),
                    x => x.HasOne(f => f.Reserva).WithMany().HasForeignKey(f => f.IdReserva),
                    x =>
                    {
                        x.ToTable("tb_usuario_reserva");

                        x.HasKey(f => new {f.IdReserva, f.IdUsuario});
                        
                        x.Property(x => x.IdReserva).HasColumnName("id_reserva").IsRequired();
                        x.Property(x => x.IdUsuario).HasColumnName("id_usuario").IsRequired();
                    }
                    );
        }
    }
}