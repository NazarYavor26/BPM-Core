using BPM_Core.DAL.Entities;

namespace BPM_Core.DAL.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetById(Guid? userId);
    }
}
