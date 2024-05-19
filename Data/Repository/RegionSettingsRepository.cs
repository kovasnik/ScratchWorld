﻿using Microsoft.EntityFrameworkCore;
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
    }
}
