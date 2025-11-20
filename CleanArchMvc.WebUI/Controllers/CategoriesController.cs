using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Application.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;




namespace CleanArchMvc.WebUI
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService; // Injeção de dependência do serviço de categorias
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        

    }
}