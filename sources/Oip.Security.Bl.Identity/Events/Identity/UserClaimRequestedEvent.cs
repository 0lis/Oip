using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class UserClaimRequestedEvent<TUserClaimsDto> : AuditEvent
{
    public UserClaimRequestedEvent(TUserClaimsDto userClaims)
    {
        UserClaims = userClaims;
    }

    public TUserClaimsDto UserClaims { get; set; }
}