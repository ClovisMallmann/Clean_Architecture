using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using AutoMapper;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        //Injeção de dependência do repositório de categorias e do Mapper
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

         public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories(); //Obtém as categorias do repositório
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity); //Mapeia as entidades para DTOs e retorna
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Create(CategoryDTO categoryDto)
        {
            //Nesse caso, recebe-se um CategoryDTO, mapeia para a entidade Category e 
            // chama o repositório para criar a categoria

            var categoryEntity = _mapper.Map<Domain.Entities.Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
        }

         public async Task Update(CategoryDTO categoryDto)
        {
            var categoyEntity = _mapper.Map<Domain.Entities.Category>(categoryDto);
            await _categoryRepository.Update(categoyEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result; //o Result é usado para obter o valor 
                                                                              // da Task de forma síncrona
            await _categoryRepository.Remove(categoryEntity);
        }

       
    }
}