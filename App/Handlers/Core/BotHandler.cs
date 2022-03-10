using App.Helpers;
using App.Modules;
using App.Services;
using Database.Contexts;
using Domain.DataModels.Config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace App.Handlers.Core
{
    public class BotHandler
    {
        private DiscordClient _discordClient;
        private CommandsNextExtension _commandsNext;

        private BotConfig? _config;

        private BaseContext _context;

        public BotHandler(BaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
            
            _config = JsonService.ParseJsonFileToModel<BotConfig>("settings.json");
        }

        public BotHandler PreConfigure(ServiceProvider services)
        {
            if (_config == null)
            {
                throw new Exception("No configuration file was found.");
            }
            
            var discordConfig = DiscordConfigurationHelper.GetDiscordConfiguration(_config.Token);
            var commandsNextConfig = DiscordConfigurationHelper.GetCommandsNextConfiguration(_config.Prefixes, services);
            var interactivityConfig = DiscordConfigurationHelper.GetInteractivityConfiguration();
            
            _discordClient = new DiscordClient(discordConfig);
            _commandsNext = _discordClient.UseCommandsNext(commandsNextConfig);

            _commandsNext.RegisterCommands<TestModule>();

            _discordClient.UseInteractivity(interactivityConfig);

            return this;
        }

        public async Task Start()
        {
            await _discordClient.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
