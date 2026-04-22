using Telegram.Bot.Types;

internal class GoGameTypeHandler : ICallbackHandler
{
    private readonly GameSessionStorage _storage;
    private readonly MessageService _msg;

    public GoGameTypeHandler(GameSessionStorage storage, MessageService msg)
    {
        _storage = storage;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data == "goGameType";

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var chatId = update.CallbackQuery!.Message!.Chat.Id;

        _storage.ActiveGames.Remove(chatId);
        _storage.SelectedPack.Remove(chatId);

        await _msg.SendAndReplaceMessage(chatId, "Выбери тему:", ct, Keyboards.GameType);
    }
}

