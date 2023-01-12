using GitGruppen.Core;
using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Data
{
    public class GitgruppenContext : DbContext
    {
        public GitgruppenContext (DbContextOptions<GitgruppenContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; } = default!;

    }
}
