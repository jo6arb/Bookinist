using Bookinist.DAL.Entity.Base;

namespace Bookinist.DAL.Entity;

public class Buyer : Person
{
    public override string ToString() => $"Покупатель {Surname} {Name} {Pathromyc}";
}