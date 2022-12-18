using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class RoleClaimsSavedEvent<TRoleClaimsDto> : AuditEvent
{
    public RoleClaimsSavedEvent(TRoleClaimsDto claims)
    {
        Claims = claims;
    }

    public TRoleClaimsDto Claims { get; set; }
}