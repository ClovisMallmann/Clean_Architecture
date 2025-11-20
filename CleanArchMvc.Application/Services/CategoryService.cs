using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using AutoMapper;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Domain.Entities.Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            return categoryDto; // Retorna o DTO após a criação
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Domain.Entities.Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
            return categoryDto; // Retorna o DTO após a atualização
        }

        public async Task<CategoryDTO> Remove(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.Remove(categoryEntity);
            return _mapper.Map<CategoryDTO>(categoryEntity); // Retorna o DTO da entidade removida
        }
    }
}