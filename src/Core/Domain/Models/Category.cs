using Domain.Primitives;

namespace Domain.Models
{
    public sealed class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
