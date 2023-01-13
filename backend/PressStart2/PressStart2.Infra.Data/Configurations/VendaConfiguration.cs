using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PressStart2.Domain.Entities;


namespace PressStart2.Infra.Data.Configurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ClienteId).IsRequired();

            builder.Property(e => e.QuantidadeItens).IsRequired();

            builder.Property(e => e.DataVenda).IsRequired();

            builder.Property(e => e.DataFaturamento).IsRequired();

            builder.Property(e => e.ValorTotal).HasPrecision(18,2) .IsRequired();

            builder.ToTable("Venda");

        }
    }
}
