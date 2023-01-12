namespace Oip.Dal.Entity;

public class BaseEntity
{
    public int ObjectId { get; set; }
    public string LocalizedName { get; set; }
    public string ExtendedProperties { get; set; }
}