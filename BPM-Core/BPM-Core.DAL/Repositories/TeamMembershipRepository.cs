using BPM_Core.DAL.DbContexts;
using BPM_Core.DAL.Entities;

namespace BPM_Core.DAL.Repositories
{
    public class TeamMembershipRepository : ITeamMembershipRepository
    {
        private readonly AppDbContext _db;

        public TeamMembershipRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(TeamMembership teamMembership)
        {
            _db.TeamMemberships.Add(teamMembership);
            _db.SaveChanges();
        }
    }
}
