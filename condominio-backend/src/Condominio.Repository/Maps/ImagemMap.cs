using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class ImagemMap : BaseDomainMap<Imagem>
    {
        public ImagemMap() : base("tb_imagem"){}

        public override void Configure(EntityTypeBuilder<Imagem> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Url).HasColumnName("local").HasMaxLength(50).IsRequired();
        }
    }
}