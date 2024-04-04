using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Domain.Abstraction;
using Domain.Exceptions;
using Domain.Models;
using Domain.Primitives;

namespace Application.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductService productService, IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Result> HandleAsync(CreateProductCommand command)
        {
            var isProductExists = await _productService.GetByNameAsync(command.Product.Name);

            if (isProductExists is not null)
            {
                return ApiError.BadRequest("Product", "Product already exists");
            }

            var product = new Product(command.Product.Name, command.Product.Price, command.Product.CategoryId);

            var result = await _productRepository.CreateAsync(product);

            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            return Result.Success();
        }
    }
}
