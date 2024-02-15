using DotNet_Training.Models.Domains;

namespace DotNet_Training.Repositories.WalkServices
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
    }
}
