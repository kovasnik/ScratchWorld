using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class LandmarkRepository : ILandmarkRepository
    {
        private readonly ApplicationDbContext _context;

        public LandmarkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Landmark landmark)
        {
            await _context.AddAsync(landmark);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Landmark landmark)
        {
            _context.Remove(landmark);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Landmark>> GetAllAsync()
        {
            return await _context.Landmarks.ToListAsync();
        }

        public async Task<IEnumerable<Landmark>> GetApprovedAsync()
        {
            return await _context.Landmarks.Where(l => l.IsApproved == true).ToListAsync();
        }

        public async Task<IEnumerable<Landmark>> GetLikedAsync(IEnumerable<int> landmarkIds)
        {
            var landmarks = await _context.Landmarks
                .Where(l => landmarkIds.Contains(l.Id))
                .ToListAsync();

            return landmarks;
        }

        public async Task UpdateAsync(Landmark landmark)
        {
            _context.Update(landmark);
            await _context.SaveChangesAsync();
        }
    }
}
