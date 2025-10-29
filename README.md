# WebApp Cadastro de produtos .NET 9 e Angular-20
Uma aplicação full stack simples para cadastro de produtos, com funcionalidades de listagem, criação, edição e exclusão.

## Api (.NET 9 Web API)
- Esta é uma API RESTful desenvolvida com **.NET 9** e **ASP.NET Core**, com foco em performance, escalabilidade e boas práticas de desenvolvimento e arquitetura.
- Desenvolvida utilizando Clean Architecture, padrão CQRS, Unit of Work, SOLID e Clean Code.
- Aplicando também teste unitário usando Mock com Mediator.
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

##  Aplicação Angular

Projeto frontend desenvolvido com **Angular 20** e **Angular Material**, utilizando arquitetura modular, tema customizado e boas práticas de UI/UX com Material Design.

###  Tecnologias

- [Angular 20](https://angular.io/)
- [TypeScript 5+](https://www.typescriptlang.org/)
- [RxJS 7+](https://rxjs.dev/)
- SCSS com theming avançado
- [ESLint](https://eslint.org/)
- [Prettier](https://prettier.io/) (opcional)
- [Tailwindcss V3] (https://v3.tailwindcss.com)

###  Instalação
#### Instale as dependências
```bash
npm install
````
#### Rode o projeto
````bash
ng serve
````
Acesse em: http://localhost:4200

###  Scripts
| Comando         | Descrição                            |
| --------------- | ------------------------------------ |
| `npm start`     | Inicia o servidor de desenvolvimento |
| `npm run build` | Gera a versão de produção            |
| `npm run lint`  | Roda o lint com ESLint               |
| `npm run test`  | Roda os testes unitários com Karma   |
| `npm run e2e`   | Roda testes de ponta a ponta (e2e)   |
