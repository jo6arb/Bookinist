
namespace Bookinist.DAL.Entity;

public class Book : Base.NamedEntity
{
    public virtual Category Category { get; set; }

    public override string ToString() => $"Книга {Name}";
}