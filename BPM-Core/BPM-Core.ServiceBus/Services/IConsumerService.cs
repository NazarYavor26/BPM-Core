using BPM_Core.ServiceBus.Models;

namespace BPM_Core.ServiceBus.Services
{
    public interface IConsumerService
    {
        void RegisterAdmin(RegisterAdminModel registerAdminModel);

        void RegisterMember(RegisterMemberModel registerMemberModel);
    }
}
