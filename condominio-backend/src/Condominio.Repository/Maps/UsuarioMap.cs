using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class UsuarioMap : BaseDomainMap<Usuario>
    {
        public UsuarioMap() : base("tb_usuario"){}

        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
            builder.Property(x => x.NumeroApartamento).HasColumnName("numero_apartamento").IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();

            builder.Property(x => x.IdContato).HasColumnName("id_contato").IsRequired();
        }
    }
}