# UsersApi

Este projeto é uma API desenvolvida em ASP.NET 6 que utiliza o padrão Repository em conjunto com o Unit of Work para a camada de persistência.

## Requisitos

Certifique-se de ter o seguinte instalado em sua máquina:

- .NET 6 SDK (pode ser baixado em https://dotnet.microsoft.com/download)

## Funcionalidades

A API UsersApi possui as seguintes funcionalidades:

- Gerenciamento de usuários
  - Criar usuário
  - Listar todos os usuários
  - Buscar usuários pelo nome

## Configuração do Banco de Dados

A API utiliza o banco de dados SQL Server InMemory para fins de demonstração e facilitar o desenvolvimento. Isso significa que não é necessário ter uma instância do SQL Server configurada. O banco de dados é criado e mantido em memória durante a execução do projeto.

## Configuração do Projeto

1. Clone este repositório em sua máquina local.

```bash
git clone https://github.com/seu-usuario/UsersApi.git
