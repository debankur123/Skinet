using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<dynamic> GetProductByIdAsync(int id);
        Task<IReadOnlyList<dynamic>> GetProductsAsync();
    }
}