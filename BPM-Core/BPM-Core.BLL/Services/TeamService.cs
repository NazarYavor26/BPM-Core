using BPM_Core.BLL.Models;
using BPM_Core.DAL.Entities;
using BPM_Core.DAL.Repositories;

namespace BPM_Core.BLL.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamMembershipRepository _teamMembershipRepository;
        private readonly ITeamRepository _teamRepository;

        public TeamService(
            IUserRepository userRepository,
            ITeamMembershipRepository teamMembershipRepository,
            ITeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _teamMembershipRepository = teamMembershipRepository;
            _teamRepository = teamRepository;
        }

        public string RegisterTeam(RegisterTeamModel registerTeamModel)
        {
            var user = _userRepository.GetById(registerTeamModel.AdminId)
                ?? throw new Exception($"User with Id {registerTeamModel.AdminId} not found");

            var team = new Team
            {
                TeamId = Guid.NewGuid(),
                AdminId = registerTeamModel.AdminId,
                TeamName = registerTeamModel.TeamName
            };

            var teamMembership = ConnectUserWithTeam(user, team);
            user.TeamMemberships.Add(teamMembership);
            team.TeamMemberships.Add(teamMembership);
            _teamMembershipRepository.Add(teamMembership);

            return team.TeamId.ToString();
        }

        public List<ResponseUserModel> GetAllTeamMembers(Guid adminId)
        {
            var users = _teamRepository.GetAllTeamMembersByAdminId(adminId);

            var responseUsers = users.Select(x => new ResponseUserModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Position = x.Position,
                Email = x.Email,
                Role = x.Role
            }).ToList();

            return responseUsers;
        }

        private TeamMembership ConnectUserWithTeam(User user, Team team, User? Supervisor = null)
        {
            return new TeamMembership
            {
                TeamMembershipId = Guid.NewGuid(),
                UserId = user.UserId,
                User = user,
                TeamId = team.TeamId,
                Team = team,
                SupervisorId = Supervisor?.UserId,
                Supervisor = Supervisor
            };
        }
    }
}
