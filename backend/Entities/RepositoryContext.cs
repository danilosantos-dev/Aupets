using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        
        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<Atuacao> Atuacoes { get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<EspecializacaoPrestador> EspecializacaoPrestadores { get; set; }
        public DbSet<AtuacaoPrestador> AtuacaoPrestadores { get; set; }

    }
}