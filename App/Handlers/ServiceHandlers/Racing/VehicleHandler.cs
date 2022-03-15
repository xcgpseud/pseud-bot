using App.Handlers.ServiceHandlers.Interfaces.Racing;
using Domain.DataModels.Racing;
using DSharpPlus.CommandsNext;
using Services.Interfaces.Racing;

namespace App.Handlers.ServiceHandlers.Racing;

public class VehicleHandler : IVehicleHandler
{
    private readonly IVehicleService _vehicleService;
    private readonly IVehicleFetchService _vehicleFetchService;

    public VehicleHandler(
        IVehicleService vehicleService,
        IVehicleFetchService vehicleFetchService
    )
    {
        _vehicleService = vehicleService;
        _vehicleFetchService = vehicleFetchService;
    }

    public async Task Create(CommandContext ctx, string vehicleUid)
    {
        var vehicle = _vehicleFetchService.FetchVehicle(vehicleUid);

        await ctx.RespondAsync(vehicle.Description);
    }

    public Task FindByName(CommandContext ctx, string nameSearch)
    {
        throw new NotImplementedException();
    }
}