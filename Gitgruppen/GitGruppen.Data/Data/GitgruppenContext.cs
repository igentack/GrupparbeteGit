using GitGruppen.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasMany(s => s.Vehicles)
                .WithMany(s => s.Member)
                .UsingEntity
        }*/

    }
}



