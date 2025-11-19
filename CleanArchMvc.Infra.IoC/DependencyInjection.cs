using Microsoft.Extensions.Configuration; // Para IConfiguration
using Microsoft.Extensions.DependencyInjection; // Para IServiceCollection
using Microsoft.EntityFrameworkCore; // Para UseSqlServer e métodos do EF
using CleanArchMvc.Infra.Data.Context; // Para ApplicationDbContext (ajuste conforme seu namespace)
using CleanArchMvc.Domain.Interfaces; // Para IProductRepository e ICategoryRepository
using CleanArchMvc.Infra.Data.Repositories; // Para ProductRepository e CategoryRepository

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

        return services;
    }


    //Com esta classe de injeção de dependência, a aplicação pode resolver as dependências
    //dos repositórios de produtos e categorias automaticamente e em qualquer lugar do projeto
    // promovendo a inversão de controle
    //e facilitando a manutenção e testabilidade do código.

}
