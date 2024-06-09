using BPM_Core.DAL.Enums;

namespace BPM_Core.ServiceBus.Models
{
    public class RegisterMemberModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Guid TeamId { get; set; }
        public Guid SupervisorId { get; set; }
    }
}
