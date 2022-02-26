namespace Bookinist.DAL.Entity;

public class Category : Base.NamedEntity
{
    public virtual ICollection<Book> Books { get; set; }

    public override string ToString() => $"Кадегория {Name} ";
}