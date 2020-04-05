using Newtonsoft.Json;

namespace B3.Infrastructure.Entity
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        public override string ToString()
        {
            return "# " + GetType().Name + ": " + JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}