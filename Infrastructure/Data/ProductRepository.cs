using Core.Interfaces;
using Infrasturucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<dynamic>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<dynamic> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product!;
        }
    }
}