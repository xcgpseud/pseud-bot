using App.Handlers.Core;
using App.Handlers.ServiceHandlers;
using App.Handlers.ServiceHandlers.Interfaces;
using Database.Contexts;
using Database.Repositories;
using Database.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        RegisterDbContexts(services);
        RegisterRepositories(services);
        RegisterServices(services);
        RegisterHandlers(services);
        RegisterMisc(services);

        var bot = services.BuildServiceProvider().GetService<BotHandler>();

        if (bot == null)
        {
            throw new Exception("NO BOT FOUND AHHHHHHHHH PANIC!");
        }
        
        bot.PreConfigure(services.BuildServiceProvider()).Start().ConfigureAwait(false).GetAwaiter().GetResult();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<ITestRepository, TestRepository>();
    }

    private static void RegisterDbContexts(IServiceCollection services)
    {
        services.AddScoped<BaseContext, SQLiteContext>();
    }

    private static void RegisterHandlers(IServiceCollection services)
    {
        services.AddScoped<ITestHandler, TestHandler>();
    }

    private static void RegisterMisc(IServiceCollection services)
    {
        services.AddScoped<BotHandler>();
    }
}