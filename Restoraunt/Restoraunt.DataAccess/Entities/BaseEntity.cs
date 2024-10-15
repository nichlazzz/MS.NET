using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.DataAccess;

public class BaseEntity : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}