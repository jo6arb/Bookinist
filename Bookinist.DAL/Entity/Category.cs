namespace Bookinist.DAL.Entity;

public class Category : Base.Entity
{
    public virtual ICollection<Book> Books { get; set; }
}