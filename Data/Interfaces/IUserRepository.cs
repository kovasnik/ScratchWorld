using ScratchWorld.Models;

namespace ScratchWorld.Data.Interfaces
{
    public interface IUserRepository
    {
        bool Save();
        bool Update(User user);
        bool Delete(User user);
        bool Add(User user);
    }
}
