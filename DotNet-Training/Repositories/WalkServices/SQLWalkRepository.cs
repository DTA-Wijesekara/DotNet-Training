using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
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

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dasunDbcontext.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }
    }
}
