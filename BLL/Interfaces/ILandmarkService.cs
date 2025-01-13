using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.BLL.Interfaces
{
    public interface ILandmarkService
    {
        Task<IEnumerable<Landmark>> GetAllAsync();
        Task<IEnumerable<Landmark>> GetApprovedAsync();
        Task<IEnumerable<Landmark>> GetLikedAsync(int likeCount);
        Task ApproveLandmark(LandmarkViewModel landmark);

    }
}
