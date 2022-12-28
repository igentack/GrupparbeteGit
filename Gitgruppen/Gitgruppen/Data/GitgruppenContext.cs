using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gitgruppen.Models;

namespace Gitgruppen.Data
{
    public class GitgruppenContext : DbContext
    {
        public GitgruppenContext (DbContextOptions<GitgruppenContext> options)
            : base(options)
        {
        }

        public DbSet<Gitgruppen.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;

        public DbSet<Gitgruppen.Models.OverViewModel> OverViewModel { get; set; } = default!;
    }
}
