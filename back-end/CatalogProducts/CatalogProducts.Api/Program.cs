using CatalogProducts.Persistence.Context;
using CatalogProducts.Persistence;
using CatalogProducts.Aplication.Services;
using CatalogProducts.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseGlobalExceptionHandler();

CreateDataBase(app);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//apenas para teste, nã pode ser usado em produção
static void CreateDataBase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}