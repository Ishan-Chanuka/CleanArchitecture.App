using Domain.Primitives;

namespace Domain.Models
{
    public sealed class Product : Entity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }
    }
}
