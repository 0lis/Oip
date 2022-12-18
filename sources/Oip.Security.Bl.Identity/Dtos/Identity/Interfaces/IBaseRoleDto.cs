namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

public interface IBaseRoleDto
{
    object Id { get; }
    bool IsDefaultId();
}