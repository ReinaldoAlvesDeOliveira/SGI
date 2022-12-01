using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Login)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.ToTable(nameof(Usuario));




        }
    }
}
