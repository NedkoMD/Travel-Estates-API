using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelEstates.Data.Abstraction.Repositories.Base;

namespace TravelEstates.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        protected Repository(TravelEstatesContext travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _travelEstatesContext
                .Set<TEntity>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public virtual async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _travelEstatesContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return entity;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _travelEstatesContext.Set<TEntity>().Add(entity);
            await _travelEstatesContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _travelEstatesContext.Set<TEntity>().Update(entity);
            await _travelEstatesContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _travelEstatesContext.Set<TEntity>().Remove(entity);
            await _travelEstatesContext.SaveChangesAsync();
        }
    }
}
