using Application.Abstractions.Services;
using Application.Products.Commands.CreateProduct;
using Domain.Exceptions;
using Domain.Models;
using Domain.Primitives;
using FluentAssertions;
using Moq;

namespace Test.Application.Products.Commands
{
    public class CreateProductCommandHandlerTest
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IGenericRepository<Product>> _genericRepositoryMock;

        public CreateProductCommandHandlerTest()
        {
            _productServiceMock = new Mock<IProductService>();
            _genericRepositoryMock = new Mock<IGenericRepository<Product>>();
        }

        [Fact]
        public async Task Handle_WhenProductExists_ShouldReturnBadRequest()
        {
            // Arrange
            var dummyProduct = new Product("dummy", 10, Guid.NewGuid());

            _productServiceMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync(dummyProduct);

            var command = new CreateProductCommand(dummyProduct);
            var handler = new CreateProductCommandHandler(_productServiceMock.Object, _genericRepositoryMock.Object);


            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ApiError.BadRequest("Product", "Product already exists"));
        }

        [Fact]
        public async Task Handle_WhenProductNotExists_ShouldReturnProductId()
        {
            // Arrange
            var dummyProduct = new Product("dummy", 10, Guid.NewGuid());

            _productServiceMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((Product?)null);
            _genericRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Product>())).ReturnsAsync(Result.Success(dummyProduct.Id));


            var command = new CreateProductCommand(dummyProduct);
            var handler = new CreateProductCommandHandler(_productServiceMock.Object, _genericRepositoryMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBe(Guid.Empty);
        }
    }
}
