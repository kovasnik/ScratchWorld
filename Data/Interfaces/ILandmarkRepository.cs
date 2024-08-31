using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface ILandmarkRepository
    {
        bool Add(Landmark landmark);
        bool Update(Landmark landmark);
        bool Delete(Landmark landmark);
        Task<IEnumerable<Landmark>> GetAll();
        bool Save();
    }
}
