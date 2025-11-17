using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


/*O trabalho do repositório é fazer a ponte entre a camada de domínio e a camada de dados
persistindo e recuperando os dados do banco de dados*/

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Injeção, no construtor, da dependência do ApplicationDbContext (banco de dados)

        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbcontext context)
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

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategoryAsync( int? id)
        {
            //Como a entidade Product tem uma relação com a entidade Category,
            //usamos o Include para trazer os dados da categoria junto com os produtos

            return await _context.Products
                .Include(c => c.Category) //Procura o produto pelo Id incluindo sua categoria.
                .SingleOrDefaultAsync(p=>p.Id == id);
        }

    }
}

