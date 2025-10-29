using CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.GetAllProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct;
using CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct;
using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = "O identificador do produto é inválido.",
                    erros = new
                    {
                        Id = new[] { "O ID informado não pode ser vazio." }
                    }
                });
            }
            var response = await _mediator.Send(new GetByIdProductRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> Updade(int id, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            if (id == 0 || id != request.Id)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = "O identificador do produto é inválido.",
                    erros = new
                    {
                        Id = new[] { "O ID informado não pode ser vazio." }
                    }
                });
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = "O identificador do produto é inválido.",
                    erros = new
                    {
                        Id = new[] { "O ID informado não pode ser vazio." }
                    }
                });
            }

            var deleteProductRequest = new DeleteProductRequest(id);

            var response = await _mediator.Send(deleteProductRequest, cancellationToken);
            return Ok(response);

        }

    }
}
