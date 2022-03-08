namespace Bookinist.DAL.Entity;

public class Category : Base.NamedEntity
{
    public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

    public override string ToString() => $"Кадегория {Name} ";
}