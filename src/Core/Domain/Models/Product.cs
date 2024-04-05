using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public sealed class Product : Entity
    {
        public Product(string name, decimal price, Guid categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public Category? Category { get; set; }
    }
}
