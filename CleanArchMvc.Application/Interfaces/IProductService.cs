
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);
        Task<ProductDTO> Create(ProductDTO productDto);
        Task<ProductDTO> Update(ProductDTO productDto);
        Task<ProductDTO> Remove(int? id);

    }
}


//Essa interface define os métodos que o serviço de categoria deve implementar.
//Ela utiliza o padrão DTO (Data Transfer Object) para transferir dados entre as camadas da aplicação,
//promovendo o encapsulamento e a separação de responsabilidades.
//Será implementada nos controladores para realizar operações relacionadas aos produtos.