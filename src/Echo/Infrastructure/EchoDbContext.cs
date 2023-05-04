using Echo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Echo.Infrastructure
{
    public class EchoDbContext : DbContext
    {
        public EchoDbContext(DbContextOptions<EchoDbContext> options) : base(options) { }

        public DbSet<EchoMessage> Messages { get; set; }
    }
}