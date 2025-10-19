using api_cadastro_produtos.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Adiciona CORS liberando tudo (apenas desenvolvimento)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<CadastroProdutosDbContext>(options =>
    options.UseInMemoryDatabase("CadastroProdutos"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAngularDev");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }