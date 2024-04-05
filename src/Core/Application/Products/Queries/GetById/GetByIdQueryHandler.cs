using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Domain.Exceptions;
using Domain.Primitives;
using Domain.ResponseModels;

namespace Application.Products.Queries.GetById
{
    public class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, ProductResponseModel>
    {
        private readonly IProductService _productService;

        public GetByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<ProductResponseModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);

            if (product == null)
            {
                return Result.Failure<ProductResponseModel>(ApiError.NotFound("Product", "Product does not exists"));
            }

            return Result.Success(product);
        }
    }
}
