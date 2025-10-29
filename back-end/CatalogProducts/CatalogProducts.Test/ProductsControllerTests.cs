using CatalogProducts.Api.Controllers;
using CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.GetAllProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct;
using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CatalogProducts.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarListaDeProdutos()
        {
            var produtos = new List<ProductResponse>
            {
                new ProductResponse { Id = 1, Name = "Produto 1", Description = "Teste 1", Price = 10.50m },
                new ProductResponse { Id = 2, Name = "Produto 2", Description = "Teste 2", Price = 10.50m }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAllProductRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(produtos);

            var result = await _controller.GetAll(CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsAssignableFrom<List<ProductResponse>>(okResult.Value);
            Assert.Equal(2, response.Count);
        }

        [Fact]
        public async Task GetById_DeveRetornarProduto()
        {
            var id = 1;
            var response = new ProductResponse { Id = id, Name = "Produto 1" };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetByIdProductRequest>(r => r.Id == id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.GetById(id, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var produto = Assert.IsType<ProductResponse>(okResult.Value);
            Assert.Equal("Produto 1", produto.Name);
        }

        [Fact]
        public async Task Create_DeveRetornarProdutoCriado()
        {
            var request = new CreateProductRequest("Novo Produto", "Teste", 10.50m);
            var response = new ProductResponse { Id = 1, Name = request.Name };

            _mediatorMock
                .Setup(m => m.Send(It.Is<CreateProductRequest>(r => r.Name == request.Name), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.Create(request, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var produto = Assert.IsType<ProductResponse>(okResult.Value);
            Assert.Equal("Novo Produto", produto.Name);
        }

        [Fact]
        public async Task Update_DeveRetornarBadRequest_QuandoIdsDiferem()
        {
            var rotaId = 1;
            var requestId = 2;
            var request = new UpdateProductRequest(requestId, "Produto Atualizado", "Teste", 10.50m);

            var result = await _controller.Update(rotaId, request, CancellationToken.None);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(400, badRequest.StatusCode);
        }

        [Fact]
        public async Task Update_DeveRetornarProdutoAtualizado()
        {
            var id = 1;
            var request = new UpdateProductRequest(id, "Produto Atualizado", "Teste", 10.50m);
            var response = new ProductResponse { Id = id, Name = request.Name };

            _mediatorMock
                .Setup(m => m.Send(It.Is<UpdateProductRequest>(r => r.Id == id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.Update(id, request, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var produto = Assert.IsType<ProductResponse>(okResult.Value);
            Assert.Equal("Produto Atualizado", produto.Name);
        }

        [Fact]
        public async Task Delete_DeveRetornarBadRequest_QuandoIdForInvalido()
        {
            var result = await _controller.Delete(0, CancellationToken.None);
            var badRequestResult = result.Result as BadRequestObjectResult;

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task Delete_DeveRetornarOk_QuandoExcluirComSucesso()
        {
            var id = 1;
            var response = new ProductResponse { Id = id, Name = "Excluído" };

            _mediatorMock
                .Setup(m => m.Send(It.Is<DeleteProductRequest>(r => r.Id == id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.Delete(id, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var produto = Assert.IsType<ProductResponse>(okResult.Value);
            Assert.Equal("Excluído", produto.Name);
        }
    }
}
