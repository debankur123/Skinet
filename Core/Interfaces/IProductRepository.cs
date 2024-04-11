using System.Dynamic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IList<ProductType>> GetProductTypesAsync();
        Task<IList<ProductBrand>> GetProductBrandsAsync();
    }

}