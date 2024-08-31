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
        public bool Add(Landmark landmark)
        {
            _context.Add(landmark);
            return Save();
        }

        public bool Delete(Landmark landmark)
        {
            _context.Remove(landmark);
            return Save();
        }

        public async Task<IEnumerable<Landmark>> GetAll()
        {
            return await _context.Landmarks.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Landmark landmark)
        {
            _context.Update(landmark);
            return Save();
        }
    }
}
