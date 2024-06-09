using BPM_Core.DAL.Entities;
using BPM_Core.DAL.Repositories;
using BPM_Core.ServiceBus.Models;

namespace BPM_Core.ServiceBus.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamMembershipRepository _teamMembershipRepository;

        public ConsumerService(
            IUserRepository userRepository,
            ITeamRepository teamRepository,
            ITeamMembershipRepository teamMembershipRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _teamMembershipRepository = teamMembershipRepository;
        }

        public void RegisterAdmin(RegisterAdminModel registerAdminModel)
        {
            _userRepository.Add(new User
            {
                UserId = registerAdminModel.UserId,
                FirstName = registerAdminModel.FirstName,
                LastName = registerAdminModel.LastName,
                Position = registerAdminModel.Position,
                Email = registerAdminModel.Email,
                Role = registerAdminModel.Role
            });
        }

        public void RegisterMember(RegisterMemberModel registerMemberModel)
        {
            var supervisor = _userRepository.GetById(registerMemberModel.SupervisorId)
               ?? throw new Exception($"Supervisor with Id {registerMemberModel.SupervisorId} not found");

            var user = new User
            {
                UserId = registerMemberModel.UserId,
                FirstName = registerMemberModel.FirstName,
                LastName = registerMemberModel.LastName,
                Position = registerMemberModel.Position,
                Email = registerMemberModel.Email,
                Role = registerMemberModel.Role,
            };

            var team = _teamRepository.GetById(registerMemberModel.TeamId)
                ?? throw new Exception($"Team with Id {registerMemberModel.TeamId} not found");

            var teamMembership = ConnectUserWithTeam(user, team, supervisor);
            teamMembership.SupervisorId = supervisor.UserId;
            teamMembership.Supervisor = supervisor;

            _userRepository.Add(user);
            _teamMembershipRepository.Add(teamMembership);
        }

        private TeamMembership ConnectUserWithTeam(User user, Team team, User Supervisor)
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
