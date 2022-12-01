using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {

        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Rua)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(6)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Pais)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable(nameof(Endereco));

        }
    }
}
