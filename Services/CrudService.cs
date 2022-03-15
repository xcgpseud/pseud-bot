using Database.Repositories.Interfaces;
using Domain.DataModels.Interfaces;
using Domain.Entities.Interfaces;
using Mapster;
using Services.Interfaces;

namespace Services;

public class CrudService<T, E> : ICrudService<T>
    where T : class, IModel
    where E : class, IEntity
{
    private readonly ICrudRepository<E> _repository;

    public CrudService(ICrudRepository<E> repository) => _repository = repository;

    public async Task<T?> GetByGuid(Guid guid)
    {
        var entity = await _repository.GetByGuid(guid);

        return entity?.Adapt<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var entities = await _repository.GetAll();

        return entities.Select(entity => entity.Adapt<T>());
    }

    public async Task<IEnumerable<T>> GetAllByPredicate(Func<T, bool> predicate)
    {
        bool EntityPredicate(E entity) => predicate(entity.Adapt<T>());

        var entities = await _repository.GetAllByPredicate(EntityPredicate);

        return entities.Select(entity => entity.Adapt<T>());
    }

    public async Task<T> Edit(T model)
    {
        var entity = model.Adapt<E>();

        var resultEntity = await _repository.Edit(entity);

        return resultEntity.Adapt<T>();
    }

    public async Task<bool> Delete(T model)
    {
        var entity = model.Adapt<E>();

        return await _repository.Delete(entity);
    }

    public async Task<T?> Create(T model)
    {
        var entity = model.Adapt<E>();

        var resultEntity = await _repository.Create(entity);

        return resultEntity?.Adapt<T>();
    }
}