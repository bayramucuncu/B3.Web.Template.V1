namespace B3.Infrastructure.Entity
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        void SoftDelete();
    }
}