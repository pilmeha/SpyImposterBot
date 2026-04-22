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
        var chatId = update.Message!.Chat.Id;

        await _msg.SendAndReplaceMessage(chatId, MessageText.ChooseGameType, ct, Keyboards.GameType);
    }
}
