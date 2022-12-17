namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseUserClaimDto
    {
        int ClaimId { get; set; }
        object UserId { get; }
    }
}
