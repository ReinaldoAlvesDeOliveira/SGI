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
    public class MatrizMap : IEntityTypeConfiguration<Matriz>
    {
        public void Configure(EntityTypeBuilder<Matriz> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeMatriz)
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

            builder.HasOne(c => c.Endereco).WithMany(c => c.Matrizes).HasForeignKey(c => c.IdEndereco);

            builder.ToTable(nameof(Matriz));





        }
    }
}
