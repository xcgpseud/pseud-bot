using Domain.DataModels.Racing;

namespace Services.Interfaces.Racing;

public interface IVehicleFetchService
{
    public Vehicle FetchVehicle(string vehicleUid);
}