namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IBaseUserClaimDto
{
    int ClaimId { get; set; }
    object UserId { get; }
}