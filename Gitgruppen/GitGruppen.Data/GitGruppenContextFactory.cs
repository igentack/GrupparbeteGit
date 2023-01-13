using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gitgruppen.Data;

namespace Gitgruppen.Data
{
    public class GitgruppenContextFactory : IDesignTimeDbContextFactory<GitgruppenContext>
    {
        public GitgruppenContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<GitgruppenContext>();
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Gitgruppen.Data;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new GitgruppenContext(options.Options);
        }
    }
}
