﻿using Domain.DataModels.Interfaces;

namespace App.Handlers.ServiceHandlers.Interfaces;

public interface ICrudHandler<T> where T : IModel
{
        public Task<T?> GetByGuid(Guid guid);
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> GetAllByPredicate(Func<T, bool> predicate);
        public Task<T> Edit(T model);
        public Task<bool> Delete(T model);
        public Task<T?> Create(T model);
}