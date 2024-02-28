using Micro.Test2.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Micro.Test2.Data
{
    public class MContext : DbContext
    {
        public MContext(DbContextOptions<MContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<hextable> hextable { get; set; }
    }
}
