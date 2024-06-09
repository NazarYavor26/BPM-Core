using BPM_Core.DAL.DbContexts;
using BPM_Core.DAL.Entities;

namespace BPM_Core.DAL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _db;

        public TeamRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
        }

        public Team? GetById(Guid? teamId)
        {
            return _db.Teams.FirstOrDefault(x => x.TeamId == teamId);
        }

        public List<User>? GetAllTeamMembersByAdminId(Guid adminId)
        {
            return _db.Teams.FirstOrDefault(x => x.AdminId == adminId)
                .TeamMemberships.Select(x => x.User).ToList();
        }
    }
}
