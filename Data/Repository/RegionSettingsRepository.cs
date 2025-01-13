using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class RegionSettingsRepository : IRegionSettingsRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionSettingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegionSettings>> GetUsersRegions(string userId)
        {
            return await _context.RegionSettings.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<RegionSettings?> GetByRegionId(RegionSettings regionSettings)
        {
            return await _context.RegionSettings.FirstOrDefaultAsync(c => c.RegionId == regionSettings.RegionId);
        }
        public async Task<RegionSettings?> GetByRegionIdNoTracking(RegionSettings regionSettings)
        {
            return await _context.RegionSettings.AsNoTracking().FirstOrDefaultAsync(c => c.RegionId == regionSettings.RegionId && c.UserId == regionSettings.UserId);
        }

        public async Task UpdateAsync(RegionSettings regionSettings)
        {
            _context.Update(regionSettings);
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(RegionSettings regionSettings)
        {
            await _context.AddAsync(regionSettings);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RegionSettings regionSettings)
        {
            _context.Remove(regionSettings);
            await _context.SaveChangesAsync();

        }
    }
}
