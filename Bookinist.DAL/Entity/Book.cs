
namespace Bookinist.DAL.Entity;

public class Book : Base.NamedEntity
{
    public virtual Category Category { get; set; }
}