using Domain.Entities.Interfaces;

namespace Database.Repositories.Interfaces
{
    public interface ICrudRepository<T> where T : IEntity
    {
        public Task<T?> GetByGuid(Guid guid);
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> GetAllByPredicate(Func<T, bool> predicate);
        public Task<T> Edit(T entity);
        public Task<bool> Delete(T entity);
        public Task<T?> Create(T entity);
    }
}
