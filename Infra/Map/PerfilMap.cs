using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.TipoPerfil)
                .IsRequired();

            builder.ToTable(nameof(Perfil));
        }
    }
}
