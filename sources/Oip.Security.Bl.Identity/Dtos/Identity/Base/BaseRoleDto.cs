using System.Collections.Generic;
using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Base;

public class BaseRoleDto<TRoleId> : IBaseRoleDto
{
    public TRoleId Id { get; set; }

    public bool IsDefaultId()
    {
        return EqualityComparer<TRoleId>.Default.Equals(Id, default);
    }

    object IBaseRoleDto.Id => Id;
}