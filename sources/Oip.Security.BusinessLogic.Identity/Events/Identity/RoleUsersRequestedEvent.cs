using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity
{
    public class RoleUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public RoleUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}