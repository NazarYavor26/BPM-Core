﻿using BPM_Core.DAL.Enums;

namespace BPM_Core.DAL.Entities
{
    public class TeamMembership
    {
        public Guid TeamMembershipId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        public Guid? SupervisorId { get; set; }
        public User? Supervisor { get; set; }
    }
}
