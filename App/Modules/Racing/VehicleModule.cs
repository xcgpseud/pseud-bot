using App.Handlers.ServiceHandlers.Interfaces.Racing;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace App.Modules.Racing;

[Group("racing"), Aliases("race")]
public class VehicleModule : BaseCommandModule
{
    private IVehicleHandler _vehicleHandler;

    public VehicleModule(IVehicleHandler vehicleHandler) => _vehicleHandler = vehicleHandler;

    [Command("createVehicle"), Aliases("createVeh", "makeVeh")]
    public async Task CreateVehicle(CommandContext ctx, string vehicleUid)
    {
        await _vehicleHandler.Create(ctx, vehicleUid);
    }
}