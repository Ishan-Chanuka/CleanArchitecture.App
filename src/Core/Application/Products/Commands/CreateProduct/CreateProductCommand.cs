using Application.Abstractions.Messaging;
using Domain.Models;

namespace Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(Product Product) : ICommand<Guid>;
}
