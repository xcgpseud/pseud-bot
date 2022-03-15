using Database.Contexts;
using Database.Repositories.Interfaces.Racing;
using Domain.Entities.Racing;

namespace Database.Repositories.Racing;

public class VehicleRepository : CrudRepository<VehicleEntity>, IVehicleRepository
{
    public VehicleRepository(BaseContext context) : base(context)
    {
    }
}