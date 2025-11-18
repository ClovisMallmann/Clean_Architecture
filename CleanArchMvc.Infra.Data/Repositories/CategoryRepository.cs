using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;


/*O trabalho do repositório é fazer a ponte entre a camada de domínio e a camada de dados
persistindo e recuperando os dados do banco de dados*/

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //Injeção, no construtor, da dependência do ApplicationDbContext (banco de dados)
       private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create (Category category)
        {
           _context.Add(category);
           await _context.SaveChangesAsync(); //Salvar as alterações no banco de dados
           return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id); //FindAsync procura pela chave primária na tabela Categories
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            //ToListAsync traz todos os registros da tabela Categories
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
       
    }
}

/*

      Task<IEnumerable<Category>> GetCategories(); //Retorna todas as categorias
      Task<Category> GetByIdAsync(int? ind); //Retorna uma categoria pelo Id

   
    }


*/