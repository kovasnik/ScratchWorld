using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
        bool Add(Region region);

        bool Update(Region region);

        bool Delete(Region region);

        bool Save();
    }
}
