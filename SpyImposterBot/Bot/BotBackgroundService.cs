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
        var receiverOptions = new ReceiverOptions();

        _bot.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            cancellationToken: stoppingToken
        );

        var me = await _bot.GetMe();
        Console.WriteLine($"Bot @{me.Username} started");

        await Task.Delay(-1, stoppingToken);
    }

    private async Task HandleUpdateAsync(
        ITelegramBotClient bot, 
        Update update,
        CancellationToken ct)
    {
        using var scope = _provide.CreateScope();

        var handler = scope.ServiceProvider.GetRequiredService<UpdateHandler>();

        await handler.HandleUpdateAsync(bot, update, ct);
    }

    private Task HandleErrorAsync(
        ITelegramBotClient bot,
        Exception exception,
        Telegram.Bot.Polling.HandleErrorSource source,
        CancellationToken ct)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }
    
}

