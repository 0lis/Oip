using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.Identity;

public class UserRoleDeletedEvent<TUserRolesDto> : AuditEvent
{
    public UserRoleDeletedEvent(TUserRolesDto role)
    {
        Role = role;
    }

    public TUserRolesDto Role { get; set; }
}