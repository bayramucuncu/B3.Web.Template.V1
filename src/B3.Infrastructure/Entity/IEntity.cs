namespace B3.Infrastructure.Entity
{
    public interface IEntity
    {

    }

    public interface IEntity<out TKey>: IEntity
    {
        TKey Id { get; }
    }
}