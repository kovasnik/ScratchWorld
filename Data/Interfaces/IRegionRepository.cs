using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
        bool Add(RegionSettings regionSettings);

        bool Update(RegionSettings regionSettings);

        bool Delete(RegionSettings regionSettings);

        bool Save();
    }
}
