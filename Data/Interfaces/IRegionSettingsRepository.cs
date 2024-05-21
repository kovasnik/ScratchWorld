using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionSettingsRepository
    {
        Task<IEnumerable<RegionSettings>> GetUsersRegions(string userId);
        Task<RegionSettings?> GetByRegionId(RegionSettings regionSettings);
        Task<RegionSettings?> GetByRegionIdNoTracking(RegionSettings regionSettings);
        bool Add(RegionSettings regionSettings);

        bool Update(RegionSettings regionSettings);

        bool Delete(RegionSettings regionSettings);

        bool Save();
    }
}
