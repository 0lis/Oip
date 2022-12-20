using System.Collections.Generic;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IUserClaimsDto : IUserClaimDto
{
    string UserName { get; set; }
    List<IUserClaimDto> Claims { get; }
    int TotalCount { get; set; }
    int PageSize { get; set; }
}