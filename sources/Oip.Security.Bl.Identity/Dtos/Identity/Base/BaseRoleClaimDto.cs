using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Base;

public class BaseRoleClaimDto<TRoleId> : IBaseRoleClaimDto
{
    public TRoleId RoleId { get; set; }
    public int ClaimId { get; set; }

    object IBaseRoleClaimDto.RoleId => RoleId;
}