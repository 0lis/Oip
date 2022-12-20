using System.ComponentModel.DataAnnotations;
using Oip.Security.Bl.Identity.Dtos.Identity.Base;
using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity;

public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
{
    [Required] public string Name { get; set; }
}