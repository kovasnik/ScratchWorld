using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public  ApplicationDbContext _context { get; set; }
        public UserRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool Update(User user)
        {
            _context.Update(user);
            return Save();
        }
        public bool Delete(User user)
        {
            _context.Remove(user);
            return Save();
        }
        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
