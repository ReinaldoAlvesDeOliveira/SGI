using Domain.Models;
using Infra.Map;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class SGIContext : DbContext
    {
        public SGIContext(DbContextOptions<SGIContext> options) : base(options) { }

        public DbSet<Congregacao> Congregracoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Matriz> Matrizes { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CongregacaoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            modelBuilder.ApplyConfiguration(new MatrizMap());
            modelBuilder.ApplyConfiguration(new MembroMap());        
            modelBuilder.ApplyConfiguration(new PerfilMap());        
            modelBuilder.ApplyConfiguration(new UsuarioMap());        
            modelBuilder.ApplyConfiguration(new UsuarioPerfilMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
