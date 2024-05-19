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

        public bool Add(RegionSettings regionSettings)
        {
            _context.Add(regionSettings);
            return Save();
        }

        public bool Delete(RegionSettings regionSettings)
        {
            _context.Remove(regionSettings);
            return Save();
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _context.Regions.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(RegionSettings regionSettings)
        {
            _context.Update(regionSettings);
            return Save();
        }
    }
}
