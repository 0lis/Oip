namespace Oip.Dal.Core.Entity;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; }
    public string Hash { get; set; }
    public string Image { get; set; }
}