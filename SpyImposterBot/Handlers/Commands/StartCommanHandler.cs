using Telegram.Bot;
using Telegram.Bot.Types;

public class StartCommandHandler : ICommandHandler
{
    private readonly ITelegramBotClient _bot;
    private const string STARTMessageCommand = "/start";

    public StartCommandHandler(ITelegramBotClient bot)
    {
        _bot = bot;
    }

    public bool CanHandle(Update update)
        => update.Message?.Text == STARTMessageCommand;
    
    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var msg = update.Message!;
        var chatId = msg.Chat.Id;

        await _bot.SendMessage(chatId, MessageText.Start, cancellationToken: ct);
    }
}

