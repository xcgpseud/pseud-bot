using Database.Contexts;
using Database.Repositories.Interfaces;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class CrudRepository<T> : ICrudRepository<T> where T : class, IEntity
{
    private BaseContext _context;
    private DbSet<T> _dbSet => _context.Set<T>();

    public CrudRepository(BaseContext context) => _context = context;
    
    public async Task<T?> GetByGuid(Guid guid)
    {
        return await _dbSet.FindAsync(guid);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllByPredicate(Func<T, bool> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task<T> Edit(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbUpdateException)
        {
            // log?
        }

        return entity;
    }

    public async Task<bool> Delete(T entity)
    {
        var existing = await GetByGuid(entity.Guid);

        if (existing == null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<T?> Create(T entity)
    {
        var result = await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();

        return result.Entity;
    }
}