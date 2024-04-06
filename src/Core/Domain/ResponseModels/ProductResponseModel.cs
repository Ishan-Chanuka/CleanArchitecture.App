namespace Domain.ResponseModels
{
    public sealed record ProductResponseModel
    {
        public ProductResponseModel(string name, decimal price, Guid id)
        {
            Name = name;
            Price = price;
            Id = id;
        }

        public ProductResponseModel() { }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
