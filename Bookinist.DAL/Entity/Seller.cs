using Bookinist.DAL.Entity.Base;

namespace Bookinist.DAL.Entity;

public class Seller : Person
{
    public override string ToString() => $"Продавец {Surname} {Name} {Pathromyc}";

}