using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsManagementAPI.Controllers;
using ProductsManagementAPI.Models;
using ProductsManagementAPI.Repository;

namespace ProductsManagementAPI.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Fixture _fixture;
        private ProductsController _controller;

        public ProductsControllerTests()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async void ProductController_GetProductList()
        {
            // Arrange
            var productList = _fixture.CreateMany<Product>(5).ToList();
            _unitOfWorkMock.Setup(rep => rep.Products.ListProducts()).ReturnsAsync(productList);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = await _controller.GetProducts();
            var obj = result as Object;

            // Assert
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void ProductController_GetProduct_Match()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            _unitOfWorkMock.Setup(rep => rep.Products.ListProduct(product.Id)).ReturnsAsync(product);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = await _controller.GetProduct(product.Id);

            // Assert
            Assert.Equal(product.Id, result.Value.Id);
        }

        [Fact]
        public async void ProductController_GetProduct_InvalidProduct()
        {
            // Arrange
            //var product = _fixture.Create<Product>();
            _unitOfWorkMock.Setup(rep => rep.Products.ListProduct(It.IsAny<int>())).ReturnsAsync(It.IsAny<Product>());
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = await _controller.GetProduct(It.IsAny<int>());
            var obj = result.Result as ObjectResult;

            // Assert
            Assert.True(obj == null);
        }

        [Fact]
        public void ProductController_CreateProduct()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            _unitOfWorkMock.Setup(rep => rep.Products.AddProduct(It.IsAny<Product>())).ReturnsAsync(product);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = _controller.PostProduct(product);

            // Assert
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void ProductController_UpdateProduct_StatusMatch()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            _unitOfWorkMock.Setup(rep => rep.Products.UpdateProduct(product.Id, product)).Returns(true);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = _controller.PutProduct(product.Id, product);

            // Assert
            Assert.Equal("RanToCompletion", result.Status.ToString());
        }

        [Fact]
        public void ProductController_UpdateProduct_NonExistingProduct()
        {
            // Arrange            
            _unitOfWorkMock.Setup(rep => rep.Products.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).Returns(true);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = _controller.PutProduct(It.IsAny<int>(), It.IsAny<Product>());
            var obj = result.Result as ObjectResult;

            // Assert
            Assert.True(obj == null);
        }

        [Fact]
        public async void ProductController_DeleteProduct_WithNoProductId()
        {
            // Arrange
            _unitOfWorkMock.Setup(rep => rep.Products.RemoveProduct(It.IsAny<int>())).ReturnsAsync(true);
            _controller = new ProductsController(_unitOfWorkMock.Object);

            // Act
            var result = await _controller.DeleteProduct(It.IsAny<int>());
            var obj = result as ObjectResult;

            // Assert
            Assert.True(obj == null);
        }

    }
}
