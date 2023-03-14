using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<Atuacao> Atuacoes { get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<EspecializacaoPrestador> EspecializacaoPrestadores { get; set; }
        public DbSet<AtuacaoPrestador> AtuacaoPrestadores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Many to Many - EspecializacaoPrestador
            builder.Entity<EspecializacaoPrestador>().HasKey(
                ep => new { ep.EspecializacaoId, ep.PrestadorId }
            );
            builder.Entity<EspecializacaoPrestador>()
                .HasOne(ep => ep.Prestador)
                .WithMany(e => e.Especializacoes)
                .HasForeignKey(ep => ep.PrestadorId);

            builder.Entity<EspecializacaoPrestador>()
                .HasOne(ep => ep.Especializacao)
                .WithMany(p => p.Prestadores)
                .HasForeignKey(ep => ep.EspecializacaoId);
            #endregion

            #region Many to Many - AtuacaoPrestador
            builder.Entity<AtuacaoPrestador>().HasKey(
                ap => new { ap.AtuacaoId, ap.PrestadorId }
            );
            builder.Entity<AtuacaoPrestador>()
                .HasOne(ap => ap.Prestador)
                .WithMany(a => a.Atuacoes)
                .HasForeignKey(ap => ap.PrestadorId);

            builder.Entity<AtuacaoPrestador>()
                .HasOne(ap => ap.Atuacao)
                .WithMany(p => p.Prestadores)
                .HasForeignKey(ap => ap.AtuacaoId);
            #endregion

            #region Seed User - Admin
            var userId = Guid.NewGuid();
            var hash = new PasswordHasher<Usuario>();
            builder.Entity<Usuario>().HasData(
                new Usuario(){
                    Id = userId,
                    Nome = "Lucas Santos de Oliveira",
                    Senha = hash.HashPassword(null, "123456"),
                    SenhaHash = hash.GetHashCode().ToString(),
                    Email = "lucas.santos@admin.admin",
                    Imagem = "",
                    EAdmin = true
                }
            ); 
            #endregion
        }
    }
}