using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Placeholder> Placeholders { get; set; }

    }
}