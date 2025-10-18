using api_cadastro_produtos.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_cadastro_produtos.Data
{
    public class CadastroProdutosDbContext : DbContext
    {
        public CadastroProdutosDbContext(DbContextOptions<CadastroProdutosDbContext> options): base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
