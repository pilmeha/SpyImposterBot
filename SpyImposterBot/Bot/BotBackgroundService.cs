using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

internal class BotBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _bot;
    private readonly UpdateHandler _handler;

    public BotBackgroundService(ITelegramBotClient bot, UpdateHandler handler)
    {
        _bot = bot;
        _handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions();

        _bot.StartReceiving(
            async (bot, update, ct) => await _handler.HandleUpdateAsync(bot, update, ct),
            async (bot, exception, source, ct) => await _handler.HandleErrorAsync(bot, exception, source, ct),
            receiverOptions,
            cancellationToken: stoppingToken
        );

        var me = await _bot.GetMe();
        Console.WriteLine($"Bot @{me.Username} started");

        await Task.Delay(-1, stoppingToken);
    }
    
}

