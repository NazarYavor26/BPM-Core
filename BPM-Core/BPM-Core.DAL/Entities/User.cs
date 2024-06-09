using BPM_Core.DAL.Enums;

namespace BPM_Core.DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public List<TeamMembership> TeamMemberships { get; set; } = new();
    }
}
