using Microsoft.EntityFrameworkCore;

namespace Goarsa.Models
{
    public class GoarsaDbContext : DbContext
    {
        public GoarsaDbContext(DbContextOptions<GoarsaDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
    }
}
