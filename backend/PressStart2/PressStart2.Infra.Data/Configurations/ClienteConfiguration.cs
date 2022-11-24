using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PressStart2.Domain.Entities;

namespace PressStart2.Infra.Data.Configurations
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Email)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(p => p.FlagAtivo)
                .IsRequired();

            builder.ToTable("Cliente");
        }
    }
       
}
