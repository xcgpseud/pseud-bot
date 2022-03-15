using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Racing;

namespace Database.Contexts
{
    public class BaseContext : DbContext
    {
        public DbSet<TestEntity> Tests => Set<TestEntity>();

        public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();
    }
}
