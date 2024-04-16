namespace Core.Persistence.Entities;

public interface IEntity<T>
{
    T Id { get; set; }
}