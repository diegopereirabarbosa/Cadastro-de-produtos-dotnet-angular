# WebApp Cadastro de produtos .NET 9 e Angular-20
Uma aplicação full stack simples para cadastro de produtos, com funcionalidades de listagem, criação, edição e exclusão.

## Api (.NET 8 Web API)
Esta é uma API RESTful desenvolvida com **.NET 9** e **ASP.NET Core**, com foco em performance, escalabilidade e boas práticas de arquitetura.

###  Funcionalidades

- CRUD completo de entidades (Produtos)
- Validações com FluentValidation
- Suporte a CORS
- Versionamento de API

###  Tecnologias Utilizadas

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- ASP.NET Core
- Docker
- Entity Framework Core
- DBInmemory
- AutoMapper
- MediatR (opcional)
- FluentValidation

###  Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Banco de dados SQL Server (ou altere a string de conexão)

###  Configuração e Execução
```bash
git clone https://github.com/diegopereirabarbosa/Cadastro-de-produtos-dotnet-angular
````
### Execute a aplicação
````bash
dotnet run
````
A API estará disponível em https://localhost:44338 ou http://localhost:5024(docker)
### Principais Endpoints - Produtos
| Método | Rota               | Descrição                     |
| ------ | ------------------ | ----------------------------- |
| GET    | /api/produtos      | Lista todos os produtos       |
| GET    | /api/produtos/{id} | Retorna um produto pelo ID    |
| POST   | /api/produtos      | Cria um novo produto          |
| PUT    | /api/produtos/{id} | Atualiza um produto existente |
| DELETE | /api/produtos/{id} | Exclui um produto pelo ID     |


