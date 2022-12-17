using System.ComponentModel.DataAnnotations;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity
{
    public class UserClaimDto<TKey> : BaseUserClaimDto<TKey>, IUserClaimDto
    {
        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}