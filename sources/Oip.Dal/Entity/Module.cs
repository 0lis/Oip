namespace Oip.Dal.Entity;

public class Module : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public string Icon { get; set; } = "file";
    public int? ParentId { get; set; }
}