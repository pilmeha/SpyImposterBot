using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

internal class BotBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _bot;
    private readonly IServiceProvider _provide;

    public BotBackgroundService(ITelegramBotClient bot, IServiceProvider provide)
    {
        _bot = bot;
        _provide = provide;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        _bot.StartReceiving(
            async (bot, update, ct) =>
            {
                using var scope = _provide.CreateScope();
                var dispatcher = scope.ServiceProvider.GetRequiredService<UpdateDispatcher>();

                await dispatcher.DispatchAsync(update, ct);
            },
            async (bot, ex, ct) =>
            {
                Console.WriteLine(ex);
            },
            cancellationToken: stoppingToken
        );

        var me = await _bot.GetMe();
        Console.WriteLine($"Bot @{me.Username} (ID: {me.Id}) started");

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}

