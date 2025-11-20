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
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        // CORREÇÃO: Alterar para GetById (com parâmetro nullable) para corresponder à interface
        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id.Value);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        // Este método parece não estar na interface - considere removê-lo ou adicionar à interface
        public async Task<ProductDTO> GetProductCategory(int categoryId)
        {
            var productsEntity = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<ProductDTO> Create(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            var created = await _productRepository.Create(productEntity);
            return _mapper.Map<ProductDTO>(created);
        }

        // CORREÇÃO: Alterar tipo de retorno para Task<ProductDTO>
        public async Task<ProductDTO> Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productEntity);
            return productDto; // Retorna o DTO após a atualização
        }

        // CORREÇÃO: Alterar tipo de retorno para Task<ProductDTO>
        public async Task<ProductDTO> Remove(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id.Value);
            await _productRepository.Remove(productEntity);
            return _mapper.Map<ProductDTO>(productEntity); // Retorna o DTO da entidade removida
        }
    }
}