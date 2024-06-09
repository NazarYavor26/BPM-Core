using BPM_Core.BLL.Models;
using BPM_Core.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPM_Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("register-team")]
        public ActionResult RegisterTeam(RegisterTeamModel createTeamModel)
        {
            var registerResult = _teamService.RegisterTeam(createTeamModel);
            return Ok(registerResult);
        }

        [HttpPost("get-all-team-members")]
        public ActionResult<List<ResponseUserModel>> GetAllTeamMembers(Guid adminId)
        {
            var teamMembers = _teamService.GetAllTeamMembers(adminId);
            return Ok(teamMembers);
        }
    }
}
