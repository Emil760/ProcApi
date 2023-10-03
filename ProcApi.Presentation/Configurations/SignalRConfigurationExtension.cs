using Microsoft.AspNetCore.SignalR.StackExchangeRedis;
using ProcApi.Application.Services.Concreates;

namespace ProcApi.Presentation.Configurations;

public static class SignalRConfigurationExtension
{
    public static void AddCustomSignalR(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection(nameof(RedisOptions)).GetChildren().ElementAt(0).Value;

        services.AddSignalR(options =>
        {
            options.EnableDetailedErrors = true;
            options.KeepAliveInterval = TimeSpan.FromMinutes(10);
        }).AddStackExchangeRedis(connectionString!);
    }

    public static void MapHubs(this WebApplication builder)
    {
        builder.MapHub<ChatHub>("hub-chat");
    }
}