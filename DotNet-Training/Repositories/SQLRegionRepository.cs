using AutoMapper;
using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Training.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly dasunDbcontext _dbcontext;
        private readonly IMapper mapper;

        public SQLRegionRepository(dasunDbcontext dbcontext , IMapper mapper)
        {
            this._dbcontext = dbcontext;
            this.mapper = mapper;
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
            var regg = await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (regg == null)
            {
                return null;
            }
            return regg;
        }

        public async Task<Region?> UpdateAsync(Guid id, UpdateRegionRequestDto region)
        {
            var existingRegion = await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion = mapper.Map(region, existingRegion);
            await _dbcontext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
