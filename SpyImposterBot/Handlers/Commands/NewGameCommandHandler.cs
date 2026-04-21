using Telegram.Bot;
using Telegram.Bot.Types;

public class NewGameCommandHandler : ICommandHandler
{
    private readonly ITelegramBotClient _bot;
    private readonly MessageService _msg;
    private const string NEWGAMEMessageCommand = "/newgame";

    public NewGameCommandHandler(ITelegramBotClient bot, MessageService msg)
    {
        _bot = bot;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.Message?.Text == NEWGAMEMessageCommand;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var msg = update.Message!;
        var chatId = msg.Chat.Id;

        await _msg.SendAndReplaceMessage(chatId, "Выбери количество игроков!", ct, Keyboards.PlayerCount);
    }
}
