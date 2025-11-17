

namespace CleanArchMvc.Infra.Ioc
{
    public class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Configuration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}

//Configurações de injeção de dependência da camada de Infraestrutura de Dados para ficar disponívels
//para as outras camadas da aplicação