using DotNet_Training.Models.Domains;

namespace DotNet_Training.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
