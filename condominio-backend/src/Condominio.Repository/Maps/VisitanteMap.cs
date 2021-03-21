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
            builder.Property(x => x.DataVisita).HasColumnName("data_visita").IsRequired();
        }
    }
}