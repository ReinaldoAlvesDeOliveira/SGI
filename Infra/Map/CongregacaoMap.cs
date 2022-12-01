using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class CongregacaoMap : IEntityTypeConfiguration<Congregacao>
    {
        public void Configure(EntityTypeBuilder<Congregacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCongregacao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Email)
                .HasColumnType("varchar (100)");

            builder.HasOne(c => c.Endereco).WithMany(c => c.Congregracoes).HasForeignKey(c => c.IdEndereco);

            builder.HasOne(c => c.Matriz).WithMany(c => c.Congregracaoes).HasForeignKey(c => c.IdMatriz);

            builder.ToTable(nameof(Congregacao));
        }
    }
}
