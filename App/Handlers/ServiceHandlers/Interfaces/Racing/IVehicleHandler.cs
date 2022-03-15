using DSharpPlus.CommandsNext;

namespace App.Handlers.ServiceHandlers.Interfaces.Racing;

public interface IVehicleHandler
{
    public Task Create(CommandContext ctx, string vehicleUid);

    public Task FindByName(CommandContext ctx, string nameSearch);
}