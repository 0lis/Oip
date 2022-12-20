using System.Collections.Generic;
using Oip.Security.Bl.Identity.Dtos.Common;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IUserRolesDto : IBaseUserRolesDto
{
    string UserName { get; set; }
    List<SelectItemDto> RolesList { get; set; }
    List<IRoleDto> Roles { get; }
    int PageSize { get; set; }
    int TotalCount { get; set; }
}