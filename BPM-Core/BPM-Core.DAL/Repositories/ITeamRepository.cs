using BPM_Core.DAL.Entities;

namespace BPM_Core.DAL.Repositories
{
    public interface ITeamRepository
    {
        void Add(Team team);

        Team? GetById(Guid? teamId);

        List<User>? GetAllTeamMembersByAdminId(Guid adminId);
    }
}
