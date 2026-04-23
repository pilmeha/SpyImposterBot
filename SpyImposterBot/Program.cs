using Telegram.Bot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using MihaZupan;
using SpyImposterBot.Database;

Env.Load();

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;

        var botToken = Environment.GetEnvironmentVariable("BOT_TOKEN")
            ?? throw new InvalidOperationException("BOT_TOKEN not set");

        var dbHost = Environment.GetEnvironmentVariable("DB_HOST")
            ?? throw new InvalidOperationException("DB_HOST not set");

        var dbPort = Environment.GetEnvironmentVariable("DB_PORT")
            ?? throw new InvalidOperationException("DB_PORT not set");

        var dbUser = Environment.GetEnvironmentVariable("DB_USER")
            ?? throw new InvalidOperationException("DB_USER not set");

        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD")
            ?? throw new InvalidOperationException("DB_PASSWORD not set");

        var dbName = Environment.GetEnvironmentVariable("DB_NAME")
            ?? throw new InvalidOperationException("DB_NAME not set");

        var connection = Environment.GetEnvironmentVariable("CONNECTION_STRING")
            ?? $"Host={dbHost};Port={dbPort};Username={dbUser};Password={dbPassword};Database={dbName}";

        // Настройка proxy
        var proxyHost = Environment.GetEnvironmentVariable("PROXY_HOST")
            ?? throw new InvalidOperationException("PROXY_HOST not set");

        var proxyPort = Environment.GetEnvironmentVariable("PROXY_PORT")
            ?? throw new InvalidOperationException("PROXY_PORT not set");

        var proxyUserName = Environment.GetEnvironmentVariable("PROXY_USERNAME")
            ?? throw new InvalidOperationException("PROXY_USERNAME not set");

        var ProxyPassword = Environment.GetEnvironmentVariable("PROXY_PASSWORD")
            ?? throw new InvalidOperationException("PROXY_PASSWORD not set");

        var proxy = new HttpToSocks5Proxy(proxyHost, int.Parse(proxyPort), proxyUserName, ProxyPassword);

        var httpClient = new HttpClient(
            new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            }
        );

        // Telegram
        services.AddSingleton<ITelegramBotClient>(
            new TelegramBotClient(botToken, httpClient)
        );

        // EF Core
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connection)
        );

        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<MessageService>();
        services.AddSingleton<GameSessionStorage>();

        // Handler
        //services.AddScoped<UpdateHandler>();
        services.AddScoped<ICallbackHandler, GameTypeHandler>();
        services.AddScoped<ICallbackHandler, PlayerCountHandler>();
        services.AddScoped<ICallbackHandler, ShowHandler>();
        services.AddScoped<ICallbackHandler, NextHandler>();
        services.AddScoped<ICallbackHandler, PlayAgainHandler>();
        services.AddScoped<ICallbackHandler, GoGameTypeHandler>();

        services.AddScoped<ICommandHandler, StartCommandHandler>();
        services.AddScoped<ICommandHandler, NewGameCommandHandler>();

        services.AddScoped<ICommandHandler, DebugPhotoHandler>();

        services.AddScoped<UpdateDispatcher>();

        // Background bot
        services.AddHostedService<BotBackgroundService>();
    });

var host = builder.Build();

// Миграции
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

await host.RunAsync();
