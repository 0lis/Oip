using System.ComponentModel.DataAnnotations;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity;

public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
{
    [Required] public string Name { get; set; }
}