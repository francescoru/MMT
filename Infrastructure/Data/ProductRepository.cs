using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
               
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _context.Products
                .Include(p => p.ProductCategory)             
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Category>> GetProductCategoriesAsync()
        {
            return await _context.Products
                            .Include(p => p.ProductCategory)
                            .Select(p=> p.ProductCategory).ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductByCategoryAsync(int categoryId)
        {
            var docs1 = _context.Products.FromSqlRaw("CALL productByCategoryId(@p0)", categoryId).ToListAsync();

            return  await docs1;
        }
    }
}
