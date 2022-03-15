using App.Handlers.ServiceHandlers.Interfaces;
using Domain.DataModels;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace App.Modules;

[Group("test")]
public class TestModule : BaseCommandModule
{
    private ITestHandler _testHandler;

    public TestModule(ITestHandler testHandler) => _testHandler = testHandler;

    [Command("works")]
    public async Task TestBotWorks(CommandContext ctx)
    {
        await ctx.RespondAsync("Yo.");
    }

    [Command("create")]
    public async Task Create(CommandContext ctx, string name, string description)
    {
        await _testHandler.Create(ctx, name, description);
    }

    [Command("find")]
    public async Task Find(CommandContext ctx, string nameSearch)
    {
        await _testHandler.FindByName(ctx, nameSearch);
    }
}