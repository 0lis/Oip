namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IUserClaimDto : IBaseUserClaimDto
{
    string ClaimType { get; set; }
    string ClaimValue { get; set; }
}