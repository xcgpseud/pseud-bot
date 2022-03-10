using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Database.Contexts
{
    public class BaseContext : DbContext
    {
        public DbSet<TestEntity> Tests => Set<TestEntity>();
    }
}
