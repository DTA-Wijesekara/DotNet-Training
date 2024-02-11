using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Training.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly dasunDbcontext _dbcontext;

        public SQLRegionRepository(dasunDbcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbcontext.Region.ToListAsync();
        }
    }
}
