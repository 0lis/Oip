using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity
{
    public class ClaimUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public ClaimUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}