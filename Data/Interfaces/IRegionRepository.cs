using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
        Task<IEnumerable<Region>> GetLikedAsync(IEnumerable<int> regionIds);
        Task AddAsync(Region region);

        Task UpdateAsync(Region region);

        Task DeleteAsync(Region region);
    }
}
