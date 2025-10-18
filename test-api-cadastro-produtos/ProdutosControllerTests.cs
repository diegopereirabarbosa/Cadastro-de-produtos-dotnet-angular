using api_cadastro_produtos.Controllers;
using System;
using api_cadastro_produtos.Data;
using api_cadastro_produtos.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc;

namespace test_api_cadastro_produtos
{
    public class ProdutosControllerTests
    {
        private ProdutosController CriarControllerComContexto(string dbName)
        {
            var options = new DbContextOptionsBuilder<CadastroProdutosDbContext>()
            .UseInMemoryDatabase(dbName) 
                .Options;

            var context = new CadastroProdutosDbContext(options);

            if (!context.Produtos.Any())
            {
                context.Produtos.Add(new Produto { Nome = "Produto Inicial", Preco = 500m, Descricao = "Primeiro teste descrição" });
                context.SaveChanges();
            }

            return new ProdutosController(context);
        }
        [Fact]
        public async Task GetProdutos_DeveRetornarLista()
        {
            var controller = CriarControllerComContexto("DbTesteProduto1");

            var result = await controller.GetProdutos();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Produto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var produtos = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);

            Assert.NotEmpty(produtos);
        }

        [Fact]
        public async Task PostProduto_DeveAdicionarProduto()
        {
            var controller = CriarControllerComContexto("DbTesteProduto2");

            var novoProduto = new Produto { Nome = "Novo produto de teste", Preco = 20m };

            var result = await controller.PostProduto(novoProduto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var produtoCriado = Assert.IsType<Produto>(createdResult.Value);

            Assert.True(produtoCriado.Id > 0);
            Assert.Equal("Novo produto de teste", produtoCriado.Nome);
        }

        [Fact]
        public async Task DeleteProduto_DeveRemoverProduto()
        {
            var controller = CriarControllerComContexto("DbTesteProduto3");

            var produto = new Produto { Nome = "Produto Para Deletar", Preco = 15m, Descricao = "Descrição do Produto Para Deletar" };
            await controller.PostProduto(produto);

            var deleteResult = await controller.DeleteProduto(produto.Id);
            Assert.IsType<NoContentResult>(deleteResult);
        }
    }
}
