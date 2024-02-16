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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("8206c0eb-c2c6-4060-99e6-f8d146ce7811"),
                    Name="dasun"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("de2b23b6-ae35-49d4-b61c-ce151716114e"),
                    Name="kkkkkkkk"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }

    }
}

