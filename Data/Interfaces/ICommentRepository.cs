using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface ICommentRepository
    {

        Task<IEnumerable<Comment>> GetAll();
        bool Add(Comment comment);

        bool Update(Comment comment);

        bool Delete(Comment comment);

        bool Save();
    }
}
