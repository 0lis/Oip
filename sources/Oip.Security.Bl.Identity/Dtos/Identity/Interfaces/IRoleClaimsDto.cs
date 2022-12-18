using System.Collections.Generic;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

public interface IRoleClaimsDto : IRoleClaimDto
{
    string RoleName { get; set; }
    List<IRoleClaimDto> Claims { get; }
    int TotalCount { get; set; }
    int PageSize { get; set; }
}