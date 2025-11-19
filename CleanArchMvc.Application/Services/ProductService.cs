using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using AutoMapper;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //Injeção de dependência do repositório de categorias e do Mapper
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    
        public async Task<IEnumerable<ProductDTO>> GetProductAsync()
        {
            var productsEntity = await _productRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var productsEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int categoryId)
        {
            var productsEntity = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<ProductDTO> Create(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            var created = await _productRepository.Create(productsEntity);
            return _mapper.Map<ProductDTO>(created);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id.Value).Result;
            await _productRepository.Remove(productEntity);
        }
    }
}


/*

      Task<Product> GetByIdAsync(int Id); //Retorna uma categoria pelo Id

      Task<IEnumerable<Product>> GetProductsByCategoryAsync(int CategoryId); 

*/