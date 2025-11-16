using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{

    public interface IProductRepository
    {
        //Task significa que o método é assíncrono 
      Task<IEnumerable<Product>> GetProductAsync(); //Retorna todas as categorias
      Task<Product> GetByIdAsync(int? ind); //Retorna uma categoria pelo Id

      Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId); //Retorna produtos por categoria

      //Metodos para manipulação de dados
      Task<Product> Create(Product product); //Retorna a categoria criada com o Id gerado
      Task<Product> Update(Product product); //Atualiza uma categoria existente
      Task<Product> Remove(Product product); //Remove uma categoria existente
    }

}


//Com esta interface será possivel acessar os dados do repositorio de produtos usando a injeçao de dependencia e
//fazendo inversão de controle, seguindo os princípios da Arquitetura Limpa (Clean Architecture).
    