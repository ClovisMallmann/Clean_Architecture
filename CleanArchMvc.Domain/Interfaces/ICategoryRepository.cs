using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{

    
    public interface ICategoryRepository
    {
        //Task significa que o método é assíncrono 
      Task<IEnumerable<Category>> GetCategories(); //Retorna todas as categorias
      Task<Category> GetByIdAsync(int? ind); //Retorna uma categoria pelo Id

      //Metodos para manipulação de dados
      Task<Category> Create(Category category); //Retorna a categoria criada com o Id gerado
      Task<Category> Update(Category category); //Atualiza uma categoria existente
      Task<Category> Remove(Category category); //Remove uma categoria existente
    }

}


//Com esta interface será possivel acessar os dados do repositorio usando a injeçao de dependencia e
//fazendo inversão de controle, seguindo os princípios da Arquitetura Limpa (Clean Architecture).
    