using Database.Repositories.Interfaces.Racing;
using Domain.DataModels.Racing;
using Domain.Entities.Racing;
using Services.Interfaces.Racing;

namespace Services.Racing;

public class VehicleService : CrudService<Vehicle, VehicleEntity>, IVehicleService
{
    public VehicleService(IVehicleRepository repository) : base(repository)
    {
    }
}