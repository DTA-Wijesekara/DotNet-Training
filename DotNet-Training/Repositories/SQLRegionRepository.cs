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

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbcontext.Region.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            _dbcontext.Region.Remove(existingRegion);
            await _dbcontext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbcontext.Region.ToListAsync();
        }
        public async Task<Region> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;

            await _dbcontext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
