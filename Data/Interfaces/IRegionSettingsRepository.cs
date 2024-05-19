using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionSettingsRepository
    {
        Task<IEnumerable<RegionSettings>> GetUsersRegions(string userId);
        bool Add(RegionSettings regionSettings);

        bool Update(RegionSettings regionSettings);

        bool Delete(RegionSettings regionSettings);

        bool Save();
    }
}
