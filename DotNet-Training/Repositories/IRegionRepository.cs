using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;

namespace DotNet_Training.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id,UpdateRegionRequestDto region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
