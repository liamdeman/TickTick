namespace TickTick.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = new Guid();
}