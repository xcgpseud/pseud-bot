using App.Handlers.Core;
using App.Handlers.ServiceHandlers;
using App.Handlers.ServiceHandlers.Interfaces;
using App.Handlers.ServiceHandlers.Interfaces.Racing;
using App.Handlers.ServiceHandlers.Racing;
using Database.Contexts;
using Database.Repositories;
using Database.Repositories.Interfaces;
using Database.Repositories.Interfaces.Racing;
using Database.Repositories.Racing;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using Services.Interfaces.Racing;
using Services.Racing;

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
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IVehicleFetchService, VehicleFetchService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<ITestRepository, TestRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
    }

    private static void RegisterDbContexts(IServiceCollection services)
    {
        services.AddScoped<BaseContext, SQLiteContext>();
    }

    private static void RegisterHandlers(IServiceCollection services)
    {
        services.AddScoped<ITestHandler, TestHandler>();
        services.AddScoped<IVehicleHandler, VehicleHandler>();
    }

    private static void RegisterMisc(IServiceCollection services)
    {
        services.AddScoped<BotHandler>();
    }
}