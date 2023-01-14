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
        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<VehicleType> VehicleType { get; set; } = default!;
        public DbSet<ParkingSpot> ParkingSpot { get; set; } = default!;
        public DbSet<Receipt> Receipt { get; set; } = default!;

    }
}



