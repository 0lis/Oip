namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IBaseUserDto
{
    object Id { get; }
    bool IsDefaultId();
}