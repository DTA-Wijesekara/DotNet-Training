using AutoMapper;
using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO.walksDtos;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Training.Repositories.WalkServices
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly dasunDbcontext dasunDbcontext;

        public SQLWalkRepository(dasunDbcontext dasunDbcontext)
        {
            this.dasunDbcontext = dasunDbcontext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dasunDbcontext.Walks.AddAsync(walk);
            await dasunDbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await dasunDbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            dasunDbcontext.Region.Remove(existingRegion);
            await dasunDbcontext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dasunDbcontext.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            var i = await dasunDbcontext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);
            if (i == null)
            {
                return null;
            }
            return i;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk alk)
        {
            var selected = await dasunDbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (selected == null)
            {
                return null;
            }
            selected.Name=alk.Name;
            selected.Description=alk.Description;
            await dasunDbcontext.SaveChangesAsync();
            return selected;
        }
    }
}
