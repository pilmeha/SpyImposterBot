using Telegram.Bot;
using Telegram.Bot.Types;

public class StartCommandHandler : ICommandHandler
{
    private readonly ITelegramBotClient _bot;
    private readonly IUserService _userService;
    private const string STARTMessageCommand = "/start";

    public StartCommandHandler(ITelegramBotClient bot, IUserService userService)
    {
        _bot = bot;
        _userService = userService;
    }

    public bool CanHandle(Update update)
        => update.Message?.Text == STARTMessageCommand;
    
    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        if (update.Message?.Text != STARTMessageCommand)
            return;

        var msg = update.Message!;
        var chatId = msg.Chat.Id;

        await _userService.CreateUser(msg.From!.Id, msg.From.Username);

        await _bot.SendMessage(chatId, MessageText.Start, cancellationToken: ct);
    }
}

