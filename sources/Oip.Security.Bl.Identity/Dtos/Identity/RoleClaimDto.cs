﻿using System.ComponentModel.DataAnnotations;
using Oip.Security.Bl.Identity.Dtos.Identity.Base;
using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity;

public class RoleClaimDto<TKey> : BaseRoleClaimDto<TKey>, IRoleClaimDto
{
    [Required] public string ClaimType { get; set; }


    [Required] public string ClaimValue { get; set; }
}