using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PressStart2.Domain.Entities;

namespace PressStart2.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);


            builder.ToTable("Usuario");
        }
    }
}
