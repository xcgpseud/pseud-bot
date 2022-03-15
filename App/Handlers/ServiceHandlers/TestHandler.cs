using App.Handlers.ServiceHandlers.Interfaces;
using Domain.DataModels;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Services.Interfaces;

namespace App.Handlers.ServiceHandlers;

public class TestHandler : ITestHandler
{
    private ITestService _testService;

    public TestHandler(ITestService testService) => _testService = testService;

    public async Task Create(CommandContext ctx, string name, string description)
    {
        var model = new Test
        {
            Name = name,
            Description = description,
            DateCreated = DateTime.UtcNow,
        };

        var result = await _testService.Create(model);

        var embedBuilder = new DiscordEmbedBuilder
        {
            Color = DiscordColor.White,
            Title = result?.Name,
            Description = result?.Description,
        };

        await ctx.RespondAsync(embedBuilder.Build());
    }

    public async Task FindByName(CommandContext ctx, string nameSearch)
    {
        var results = await _testService.GetAllByPredicate(
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