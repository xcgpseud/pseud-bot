using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace App.Helpers;

public class DiscordConfigurationHelper
{
    private const int TimeoutSeconds = 30;

    public static DiscordConfiguration GetDiscordConfiguration(string token)
    {
        return new DiscordConfiguration
        {
            Token = token,
            TokenType = TokenType.Bot,

            AutoReconnect = true,

            Intents = DiscordIntents.AllUnprivileged,
        };
    }

    public static CommandsNextConfiguration GetCommandsNextConfiguration(
        List<string> prefixes,
        ServiceProvider services
    )
    {
        return new CommandsNextConfiguration
        {
            StringPrefixes = prefixes,
            Services = services,
        };
    }

    public static InteractivityConfiguration GetInteractivityConfiguration()
    {
        return new InteractivityConfiguration
        {
            PollBehaviour = PollBehaviour.KeepEmojis,
            Timeout = TimeSpan.FromSeconds(TimeoutSeconds),
        };
    }
}