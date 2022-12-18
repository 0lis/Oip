using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;

public class BaseUserClaimDto<TUserId> : IBaseUserClaimDto
{
    public TUserId UserId { get; set; }
    public int ClaimId { get; set; }

    object IBaseUserClaimDto.UserId => UserId;
}