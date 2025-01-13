using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionSettingsRepository
    {
        Task<IEnumerable<RegionSettings>> GetUsersRegions(string userId);
        Task<RegionSettings?> GetByRegionId(RegionSettings regionSettings);
        Task<RegionSettings?> GetByRegionIdNoTracking(RegionSettings regionSettings);
        Task AddAsync(RegionSettings regionSettings);

        Task UpdateAsync(RegionSettings regionSettings);

        Task DeleteAsync(RegionSettings regionSettings);
    }
}
