using Microsoft.EntityFrameworkCore;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Comment comment)
        {
            _context.Add(comment);
            return Save();
        }

        public bool Delete(Comment comment)
        {
            _context.Remove(comment);
            return Save();
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Comment comment)
        {
            _context.Update(comment);
            return Save();
        }
    }
}
