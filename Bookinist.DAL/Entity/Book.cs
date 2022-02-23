
namespace Bookinist.DAL.Entity;

public class Book : Base.Entity
{
    public virtual Category Category { get; set; }
}