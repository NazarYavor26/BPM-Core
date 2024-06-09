namespace BPM_Core.DAL.Entities
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public Guid AdminId { get; set; }
        public string TeamName { get; set; }
        public List<TeamMembership> TeamMemberships { get; set; } = new();
    }
}
