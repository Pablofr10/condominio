using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class EnderecoMap : BaseDomainMap<Endereco>
    {
        public EnderecoMap() : base("tb_endereco"){}

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Apartamento).HasColumnName("apartamento").HasMaxLength(5).IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(100).IsRequired();
        }
    }
}