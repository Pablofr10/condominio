

using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Maps
{
    public class ContatoMap : BaseDomainMap<Contato>
    {
        public ContatoMap() : base("tb_contato"){}

        public override void Configure(EntityTypeBuilder<Contato> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Telefone).HasColumnName("telefone").HasMaxLength(12).IsRequired();
            builder.Property(x => x.Celular).HasColumnName("celular").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(50).IsRequired();
            
            builder.HasOne(x => x.Usuario).WithOne(x => x.Contato).HasForeignKey<Usuario>(x => x.IdContato);

        }
    }
}