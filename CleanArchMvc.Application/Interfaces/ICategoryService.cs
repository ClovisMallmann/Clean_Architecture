
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task<CategoryDTO> Create(CategoryDTO categoryDto);
        Task<CategoryDTO> Update(CategoryDTO categoryDto);
        Task<CategoryDTO> Remove(int? id);

    }
}


//Essa interface define os métodos que o serviço de categoria deve implementar.
//Ela utiliza o padrão DTO (Data Transfer Object) para transferir dados entre as camadas da aplicação,
//promovendo o encapsulamento e a separação de responsabilidades.
//Será implementada nos controladores para realizar operações relacionadas às categorias.