using Core.Entities;
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
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _context.Products
            .Include(x => x.ProductType)
            .Include(y => y.ProductBrand)
            .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
            .Include(x => x.ProductType)
            .Include(y => y.ProductBrand)
            .SingleOrDefaultAsync(x => x.Id == id);
            return product!;
        }

        public async Task<IList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }

        public async Task<IList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _context.ProductBrands.ToListAsync();
            return productBrands;
        }
    }
}