using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Domain.Exceptions;
using Domain.Models;
using Domain.Primitives;

namespace Application.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IProductService _productService;
        private readonly IGenericRepository<Product> _productRepository;

        public CreateProductCommandHandler(IProductService productService, IGenericRepository<Product> productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var isProductExists = await _productService.GetByNameAsync(command.Product.Name);

            if (isProductExists is not null)
            {
                return Result.Failure<Guid>(
                    ApiError.BadRequest("Product", "Product already exists"));
            }

            var product = new Product(command.Product.Name, command.Product.Price, command.Product.CategoryId);

            var result = await _productRepository.CreateAsync(product);

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            return product.Id;
        }
    }
}
