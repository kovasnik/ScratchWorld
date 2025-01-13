using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Region region)
        {
            await _context.AddAsync(region);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region region)
        {
            _context.Remove(region);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<IEnumerable<Region>> GetLikedAsync(IEnumerable<int> regionIds)
        {
            var regions = await _context.Regions
                .Where(l => regionIds.Contains(l.Id))
                .ToListAsync();

            return regions;
        }

        public async Task UpdateAsync(Region region)
        {
            _context.Update(region);
            await _context.SaveChangesAsync();
        }
    }
}
