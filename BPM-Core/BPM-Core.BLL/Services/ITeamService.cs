using BPM_Core.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM_Core.BLL.Services
{
    public interface ITeamService
    {
        string RegisterTeam(RegisterTeamModel createTeamModel);

        List<ResponseUserModel> GetAllTeamMembers(Guid adminId);
    }
}
