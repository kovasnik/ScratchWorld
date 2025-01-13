using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Likes>> GetRegionLikes();
        Task<IEnumerable<Likes>> GetLandmarkLikes();
        Task<IEnumerable<int>> GetRegionsFilteredByLikes(int likeCount);
        Task<IEnumerable<int>> GetLandmarksFilteredByLikes(int likeCount);
        Task AddAsync(Likes likes);
        Task UpdateAsync(Likes likes);
        Task DeleteAsync(Likes likes);
    }
}
