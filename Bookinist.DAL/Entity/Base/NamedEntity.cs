using System.ComponentModel.DataAnnotations;

namespace Bookinist.DAL.Entity.Base;

public abstract class NamedEntity : Entity
{
    [Required]
    public string Name { get; set; }

}