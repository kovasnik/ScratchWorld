using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class LikesRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;
        public LikesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Likes like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Likes like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Likes>> GetLandmarkLikes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> GetLandmarksFilteredByLikes(int likeCount)
        {
            var landmarksId = await _context.Likes
                .Where(l => l.LandmarkId.HasValue)
                .GroupBy(l => l.LandmarkId)
                .Select(group => new
                {
                    LandmarkId = group.Key.Value,
                    LikeCount = group.Count()
                })
                .Where(x => x.LikeCount == likeCount)
                .Select(x => x.LandmarkId)
                .ToListAsync();

            return landmarksId;
        }

        public async Task<IEnumerable<Likes>> GetRegionLikes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> GetRegionsFilteredByLikes(int likeCount)
        {
            var regionId = await _context.Likes
                .Where(l => l.RegionId.HasValue)
                .GroupBy(l => l.LandmarkId)
                .Select(group => new
                {
                    LandmarkId = group.Key.Value,
                     LikeCount = group.Count()
                })
                .Where(x => x.LikeCount == likeCount)
                .Select(x => x.LandmarkId)
                .ToListAsync();

            return regionId;
        }

        public async Task UpdateAsync(Likes like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
        }
    }
}
