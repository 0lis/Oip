namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IUserChangePasswordDto : IBaseUserChangePasswordDto
{
    string UserName { get; set; }
    string Password { get; set; }
    string ConfirmPassword { get; set; }
}