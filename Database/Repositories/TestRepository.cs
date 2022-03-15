using Database.Contexts;
using Database.Repositories.Interfaces;
using Domain.Entities;

namespace Database.Repositories
{
    public class TestRepository : CrudRepository<TestEntity>, ITestRepository
    {
        public TestRepository(BaseContext context) : base(context)
        {
        }
    }
}
