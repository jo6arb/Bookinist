using Bookinist.Interfaces;

namespace Bookinist.DAL.Entity.Base;

public abstract class Entity : IEntity
{
    public int Id { get; set; }
}