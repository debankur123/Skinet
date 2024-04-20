using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrasturucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;
        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var output = await _storeContext.Set<T>().FindAsync(id);
            return output!;
        }
        public async Task<IList<T>> ListAllAsync()
        {
            var output = await _storeContext.Set<T>().ToListAsync();
            return output!;
        }
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            var output = await ApplySpecifications(spec).FirstOrDefaultAsync();
            return output!;
        }
        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            var output = await ApplySpecifications(spec).ToListAsync();
            return output;
        }
        public async Task<int> CountProductAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }

        public IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }
    }
}