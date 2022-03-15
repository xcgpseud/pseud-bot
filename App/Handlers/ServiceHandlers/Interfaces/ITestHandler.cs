using Domain.DataModels;
using DSharpPlus.CommandsNext;

namespace App.Handlers.ServiceHandlers.Interfaces;

public interface ITestHandler
{
    public Task Create(CommandContext ctx, string name, string description);

    public Task FindByName(CommandContext ctx, string nameSearch);
}