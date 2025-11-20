using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using AutoMapper;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile //A classe Profile vem do AutoMapper
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}