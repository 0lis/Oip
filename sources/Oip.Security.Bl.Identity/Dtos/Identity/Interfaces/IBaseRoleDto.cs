namespace Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

public interface IBaseRoleDto
{
    object Id { get; }
    bool IsDefaultId();
}