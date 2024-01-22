# Library API

**Descrição**

 Esse é um projeto de API de biblioteca no framework ASP.NET Core para gerenciar Livros e autores.

**Recursos**

* CRUD com livros de autores
* Paginação com livros
* Armazenamento em SQLite

**Objetivos**

O objetivo foi basicamente para eu aprender a mexer com o Entity Framework :p.

**Instruções de instalação**

**Requisitos de sistema**

* .NET 8.0.0
* Entity Framework Core
* SQLite

**Instalação do aplicativo**

1. Entre na pasta do aplicativo
2. Execute `dotnet ef migrations add InitialCreate` para iniciar uma migração, caso ainda não tenha sido feita
3. Execute `dotnet ef database update` para criar o banco de dados e aplicar a migração a ele
4. Execute `dotnet run` para iniciar a API em modo de desenvolvimento

**Screenshots**

![Exemplo de partida no terminal](other/Screenshot1.png)