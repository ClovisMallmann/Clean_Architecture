using Microsoft.Extensions.Configuration; // Para IConfiguration
using Microsoft.Extensions.DependencyInjection; // Para IServiceCollection
using Microsoft.EntityFrameworkCore; // Para UseSqlServer e métodos do EF
using AutoMapper; // Para AutoMapper
using CleanArchMvc.Infra.Data.Context; // Para ApplicationDbContext
using CleanArchMvc.Domain.Interfaces; // Para IProductRepository e ICategoryRepository
using CleanArchMvc.Infra.Data.Repositories; // Para ProductRepository e CategoryRepository
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Interfaces; // Para DomainToDTOMappingProfile
using CleanArchMvc.Application.Services; // Para ProductService e CategoryService


namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Adiciona o DbContext com a string de conexão do appsettings.json
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Adiciona os repositórios ao contêiner de injeção de dependência
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();  
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }


    //Com esta classe de injeção de dependência, a aplicação pode resolver as dependências
    //dos repositórios de produtos e categorias automaticamente e em qualquer lugar do projeto
    // promovendo a inversão de controle
    //e facilitando a manutenção e testabilidade do código.

}
