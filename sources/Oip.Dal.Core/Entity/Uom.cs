namespace Oip.Dal.Core.Entity;

public class Uom : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Formula { get; set; }
    public int? BaseUomId { get; set; }
}