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
        var model = new Test
        {
            Name = name,
            Description = description,
            DateCreated = DateTime.UtcNow,
        };

        var result = await _testHandler.Create(model);

        var embedBuilder = new DiscordEmbedBuilder
        {
            Color = DiscordColor.White,
            Title = result?.Name,
            Description = result?.Description,
        };

        await ctx.RespondAsync(embedBuilder.Build());
    }

    [Command("find")]
    public async Task Find(CommandContext ctx, string nameSearch)
    {
        var results = await _testHandler.GetAllByPredicate(
            (Test test) => test.Name.ToLower().Contains(nameSearch.ToLower())
        );

        var embedBuilder = new DiscordEmbedBuilder
        {
            Color = DiscordColor.Gold,
            Title = $"Results ({results.Count()})"
        };
        
        foreach (var result in results)
        {
            embedBuilder.AddField(result.Name, result.Description);
        }

        await ctx.RespondAsync(embedBuilder.Build());
    }
}