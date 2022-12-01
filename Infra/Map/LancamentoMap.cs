using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.DataLancamento)
               .IsRequired();

            builder.Property(c => c.Valor)
                .IsRequired();
            
            builder.HasOne(c => c.Matriz)
                .WithMany(c => c.Lancamentos).HasForeignKey(c => c.IdMatriz);

            builder.HasOne(c => c.Congregracao)
                .WithMany(c => c.Lancamentos).HasForeignKey(c => c.IdCongregracao);

            builder.HasOne(c => c.Membro)
                .WithMany(c => c.Lancamentos).HasForeignKey(c => c.IdMenbro);

            builder.ToTable(nameof(Lancamento));




        }
    }
}
