using Application.Abstractions.Messaging;
using Domain.ResponseModels;

namespace Application.Products.Queries.GetAllProducts
{
    public sealed record GetAllProductsQuery() : IQuery<IEnumerable<ProductResponseModel>>;
}
