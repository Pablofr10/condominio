using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class UsuarioReservaMap : BaseDomainMap<UsuarioReserva>
    {
        public UsuarioReservaMap() : base("tb_usuario_reserva"){}

        public override void Configure(EntityTypeBuilder<UsuarioReserva> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.IdReserva).HasColumnName("id_reserva").IsRequired();
            builder.HasOne(x => x.Reserva).WithMany(x => x.Usuarios).HasForeignKey(x => x.IdReserva);
            
            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario").IsRequired();
            builder.HasOne(x => x.Usuario).WithMany(x => x.Reservas).HasForeignKey(x => x.IdUsuario);
        }
    }
}