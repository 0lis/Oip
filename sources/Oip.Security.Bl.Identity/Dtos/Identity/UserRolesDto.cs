using System.Collections.Generic;
using System.Linq;
using Oip.Security.BusinessLogic.Identity.Dtos.Common;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity;

public class UserRolesDto<TRoleDto, TKey> : BaseUserRolesDto<TKey>, IUserRolesDto
    where TRoleDto : RoleDto<TKey>
{
    public UserRolesDto()
    {
        Roles = new List<TRoleDto>();
    }

    public List<TRoleDto> Roles { get; set; }

    public string UserName { get; set; }

    public List<SelectItemDto> RolesList { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    List<IRoleDto> IUserRolesDto.Roles => Roles.Cast<IRoleDto>().ToList();
}