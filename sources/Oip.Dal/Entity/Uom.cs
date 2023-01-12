namespace Oip.Dal.Entity;

public class Uom : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Formula { get; set; } = string.Empty;
    public int? BaseUomId { get; set; }
}