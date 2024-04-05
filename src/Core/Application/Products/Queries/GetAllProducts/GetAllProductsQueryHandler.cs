using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Domain.Exceptions;
using Domain.Primitives;
using Domain.ResponseModels;

namespace Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductResponseModel>>
    {
        private readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<IEnumerable<ProductResponseModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();

            if (products is null)
            {
                return Result.Failure<IEnumerable<ProductResponseModel>>(ApiError.NotFound("Product", "Product does not exists"));
            }

            return Result.Success(products);
        }
    }
}
