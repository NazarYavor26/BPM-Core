using BPM_Core.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM_Core.DAL.Repositories
{
    public interface ITeamMembershipRepository
    {
        void Add(TeamMembership teamMembership);
    }
}
