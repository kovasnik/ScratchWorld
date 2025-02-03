using ScratchWorld.Models;
using ScratchWorld.ViewModels;
using System.Security.Claims;

namespace ScratchWorld.BLL.Interfaces
{
    public interface ILandmarkService
    {
        Task<IEnumerable<Landmark>> GetAllAsync();
        Task<IEnumerable<Landmark>> GetUsersLandmarksAsync(ClaimsPrincipal user);
        Task<IEnumerable<Landmark>> GetSharedAsync();
        Task<IEnumerable<Landmark>> GetLikedAsync(int likeCount);
        Task<int> CreateLandmarkAsync(LandmarkViewModel landmarkViewModel, ClaimsPrincipal claimsPrincipal);
        Task DeleteLandmarkAsync(int landmarkId);
        Task UpdateLandmarkAsync(LandmarkViewModel landmarkViewModel, ClaimsPrincipal claimsPrincipal);

    }
}
