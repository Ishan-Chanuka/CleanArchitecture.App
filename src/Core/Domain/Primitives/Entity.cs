namespace Domain.Primitives
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity() { }

        protected Entity(Guid id) => Id = id;
    }
}
