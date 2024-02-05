using DotNet_Training.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Training.Context
{
    public class dasunDbcontext : DbContext
    {
        public dasunDbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
