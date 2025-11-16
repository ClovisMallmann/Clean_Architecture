# Clean Architecture

Projeto baseado no curso de Clean Architecture do Professor J.C. Macoratti.

## 📋 Escopo Geral

Criar um projeto web para gerenciar produtos e categorias, que pode ser usado para criar um catálogo de produtos de vendas.

## ⚙️ Funcionalidades

- **CRUD** completo para Produtos e Categorias

## 🏗️ Modelos de Domínio

### Product
- `Id` (int, Identity)
- `Name` (string)
- `Description` (string)
- `Price` (decimal)
- `Stock` (int)
- `Image` (string)

### Category
- `Id` (int, Identity)
- `Name` (string)

## 🏛️ Arquitetura

- **MVC**
- **Repository Pattern**
- **CQRS**

## 💾 Tecnologias e Ferramentas

- **Banco de Dados:** SQL Server
- **Provedor:** Microsoft.EntityFrameworkCore.SqlServer
- **Ferramentas para Migrations:** Microsoft.EntityFrameworkCore.Tools
- **ORM:** Entity Framework Core

## 🔗 Relacionamento

- **Category - Product:** Relacionamento um-para-muitos (1:N)

## 📝 Nomenclaturas

- CamelCase e PascalCase

## 🗂️ Estrutura da Solução

A solução é composta por 5 projetos:

### Projetos Principais

1. **CleanArchMvc.Domain**
   - Modelos de Domínio
   - Regras de negócio
   - Interfaces

2. **CleanArchMvc.Application**
   - Regras de domínio da aplicação
   - Mapeamentos
   - Serviços
   - DTOs
   - CQRS

3. **CleanArchMvc.Infra.Data**
   - Entity Framework Core
   - Contexto
   - Configurações
   - Migrations
   - Repository

4. **CleanArchMvc.Infra.IoC**
   - Dependency Injection
   - Registro de serviços
   - Definição de tempo de vida dos serviços

5. **CleanArchMvc.WebUi**
   - MVC
   - Controllers
   - Views
   - Filtros
   - ViewModels

## 🏗️ Estrutura Detalhada por Camada

### **Domain Layer**
- **Entities**
  - Product Entity
  - Category Entity
  - Account (User)
- **Interfaces**
  - IProductRepository
  - ICategoryRepository
  - IAuthenticate
  - ISeedUserRoleInitial
  - IUser
- **Validation**

### **Application Layer**
- **Services**
  - ProductService
  - CategoryService
- **Interfaces**
  - IProductService
  - ICategoryService
- **DTOs**
  - ProductDTO
  - CategoryDTO
- **CQRS**
  - Commands
  - Queries
  - Handlers
- **Mappings**
  - DomainToViewModel
  - ViewModelToDomain
- **Exceptions**

### **Infra.Data Layer**
- **Repositories**
  - ProductRepository
  - CategoryRepository
- **Context**
  - ApplicationDbContext
- **Migrations**
- **Identity**

### **Infra.IoC Layer**
- **DependencyInjection** (Configuração de injeção de dependência)

### **WebUI Layer**
- **Controllers**
  - AccountController
  - CategoriesController
  - ProductsController
- **Views**
- **Filters**
- **Components**
- **ViewModels**
- **MapConfig** (Configuração do AutoMapper)

## 🔄 Diagrama de Dependências

```
Domain ← Application, Data ← IoC ← WebUI
```

## 🧪 Projeto de Testes

- **CleanArchMvc.Domain.Tests**
- **Ferramenta:** xUnit Test Project

---

*Desenvolvido seguindo os princípios de Clean Architecture*
