using Application.Abstractions.Messaging;
using Domain.ResponseModels;

namespace Application.Products.Queries.GetById
{
    public sealed record GetByIdQuery(Guid Id) : IQuery<ProductResponseModel>;
}
