using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3, ErrorMessage ="The Name must have at least 3 characters")]
        [MaxLength(100, ErrorMessage ="The Name must have a maximum of 100 characters")]
        [Display(Name ="Nome da Categoria")]
        public string Name {get;set;}


        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5, ErrorMessage ="The Description must have at least 3 characters")]
        [MaxLength(200, ErrorMessage ="The Description must have a maximum of 100 characters")]
        [Display(Name ="Descrição do Produto")]
        public string Description { get; private set; }
        
        [Required(ErrorMessage = "The Price is required")]
        [Column(TypeName ="decimal(18,2)")]
        [Display(Name ="Preço do Produto")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The Stock is required")]
        [Display(Name ="Estoque do Produto")]
        [Range(1, 9999, ErrorMessage ="The Stock must be equal or greater than zero")]
        public int Stock { get; private set; }
        [MaxLength(250)]
        [Display(Name = "Product Image")]
        public string Image { get; set; }
        
        public Category Category { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; } 


    }
}