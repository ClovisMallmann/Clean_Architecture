using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;


/*O trabalho do repositório é fazer a ponte entre a camada de domínio e a camada de dados
persistindo e recuperando os dados do banco de dados*/

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Injeção, no construtor, da dependência do ApplicationDbContext (banco de dados)

        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create (Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _context.Remove(product);
            await  _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // ProductRepository.cs - Método corrigido
public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
{
    return await _context.Products
        .Include(c => c.Category)
        .Where(p => p.CategoryId == categoryId) // Filtra pela categoria
        .ToListAsync();
}

    }
}


