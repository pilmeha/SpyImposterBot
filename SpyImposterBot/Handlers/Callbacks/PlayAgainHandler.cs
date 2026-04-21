using Telegram.Bot.Types;

internal class PlayAgainHandler : ICallbackHandler
{
    private readonly GameSessionStorage _storage;
    private readonly MessageService _msg;
    private const string PLAYAGAINMessage = "playAgain";

    public PlayAgainHandler(GameSessionStorage storage, MessageService msg)
    {
        _storage = storage;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data == PLAYAGAINMessage;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;

        _storage.ActiveGames.Remove(chatId);

        await _msg.SendAndReplaceMessage(chatId, "Начнём заново 👇\nВыбери количество игроков:", ct, Keyboards.PlayerCount);
    }
}

