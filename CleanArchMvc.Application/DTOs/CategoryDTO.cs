using System.ComponentModel.DataAnnotations;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3, ErrorMessage ="The Name must have at least 3 characters")]
        [MaxLength(100, ErrorMessage ="The Name must have a maximum of 100 characters")]
        [Display(Name ="Nome da Categoria")]
        public string Name {get;set;}
    }

}