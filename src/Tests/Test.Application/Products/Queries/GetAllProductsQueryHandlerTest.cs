using Application.Abstractions.Services;
using Application.Products.Queries.GetAllProducts;
using Domain.Exceptions;
using Domain.Models;
using Domain.ResponseModels;
using FluentAssertions;
using Moq;

namespace Test.Application.Products.Queries
{
    public class GetAllProductsQueryHandlerTest
    {
        private readonly Mock<IProductService> _productServiceMock;

        public GetAllProductsQueryHandlerTest()
        {
            _productServiceMock = new Mock<IProductService>();
        }

        [Fact]
        public async Task Handle_WhenProductsNotExists_ShouldReturnNotFound()
        {
            // Arrange
            _productServiceMock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync((IEnumerable<ProductResponseModel>)null);

            var query = new GetAllProductsQuery();
            var handler = new GetAllProductsQueryHandler(_productServiceMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ApiError.NotFound("Product", "Product does not exists"));
        }


        [Fact]
        public async Task Handle_WhenProductsExists_ShouldReturnProducts()
        {
            // Arrange
            var dummyProducts = new List<Product>
            {
                new Product("dummy1", 10, Guid.NewGuid()),
                new Product("dummy2", 20, Guid.NewGuid())
            };

            IEnumerable<ProductResponseModel> dummyProductResponses = dummyProducts.Select(p => new ProductResponseModel(p.Name, p.Price, p.Id));
            _productServiceMock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(dummyProductResponses);

            var query = new GetAllProductsQuery();
            var handler = new GetAllProductsQueryHandler(_productServiceMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeEmpty();
            result.Value.Count().Should().Be(2);
        }
    }
}
