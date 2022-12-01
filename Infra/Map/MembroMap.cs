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
    public class MembroMap : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Mae)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Whatsapp)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.EGenero)
               .IsRequired();

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(c => c.DataBatismoAgua);

            builder.Property(c => c.Pai)
                .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Endereco).WithMany(c => c.Membros).HasForeignKey(c => c.IdEndereco);
            builder.HasOne(c => c.Matriz).WithMany(c => c.Membros).HasForeignKey(c => c.IdMatriz);
            builder.HasOne(c => c.Congregracao).WithMany(c => c.Membros).HasForeignKey(c => c.IdCongregracao);

            builder.ToTable(nameof(Membro));
        }
    }
}
