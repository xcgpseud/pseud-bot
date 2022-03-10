using Database.Contexts;
using Database.Repositories.Interfaces;
using Domain.Entities;

namespace Database.Repositories
{
    public class TestRepository : ITestRepository
    {
        private BaseContext _context;

        public TestRepository(BaseContext context) => _context = context;

        public async Task<TestEntity?> GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TestEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TestEntity>> GetAllByPredicate(Func<TestEntity, bool> predicate)
        {
            var results = _context.Tests.Where(predicate);

            return results;
        }

        public async Task<TestEntity> Edit(TestEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(TestEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TestEntity?> Create(TestEntity entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
