using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class UsuarioPerfilMap : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasKey(c => new { c.IdPerfil, c.IdUsuario });

            builder.HasOne(c => c.Usuario)
                .WithMany(c => c.UsuarioPerfis).HasForeignKey(c => c.IdUsuario);

            builder.HasOne(c => c.Perfil)
                .WithMany(c => c.UsuarioPerfis).HasForeignKey(c => c.IdPerfil);

            builder.ToTable(nameof(UsuarioPerfil));
        }
    }
}
