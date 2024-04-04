using Application.Abstractions;
using Domain.Abstraction;
using Domain.Exceptions;
using Domain.Models;
using Domain.Primitives;

namespace Application.Products.Commands
{
    public sealed record CreateProductCommand(Product Product) : ICommand;

    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductService productService, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> HandleAsync(CreateProductCommand command)
        {
            var isProductExists = await _productService.GetByNameAsync(command.Product.Name);

            if (isProductExists is not null)
            {
                return ApiError.BadRequest("Product", "Product already exists");
            }



            throw new NotImplementedException();
        }
    }
}
