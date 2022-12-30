using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Data
{
    public class GitgruppenContext : DbContext
    {
        public GitgruppenContext(DbContextOptions<GitgruppenContext> options)
            : base(options)
        {
        }

        public DbSet<Gitgruppen.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;

    }
}
