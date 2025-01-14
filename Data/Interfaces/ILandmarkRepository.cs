using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface ILandmarkRepository
    {
        Task AddAsync(Landmark landmark);
        Task UpdateAsync(Landmark landmark);
        Task DeleteAsync(Landmark landmark);
        Task<Landmark> FindLandmarkByIdAsync(int landmarkId);
        Task<IEnumerable<Landmark>> GetAllAsync();
        Task<IEnumerable<Landmark>> GetApprovedAsync();
        Task<IEnumerable<Landmark>> GetLikedAsync(IEnumerable<int> landmarkIds);
        Task<IEnumerable<Landmark>> GetUsersLandmarksAsync(string userId);
        Task<IEnumerable<Landmark>> GetSharedAsync();
    }
}
