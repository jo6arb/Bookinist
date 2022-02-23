namespace Bookinist.DAL.Entity.Base;

public abstract class Person : NamedEntity
{
    public string Surname { get; set; }
    public string Pathromyc { get; set; }
}