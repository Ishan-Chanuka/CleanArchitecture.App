using Domain.Primitives;

namespace Domain.Models
{
    public sealed class Product : Entity
    {
        public Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }
    }
}
