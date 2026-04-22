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
        var chatId = update.CallbackQuery!.Message!.Chat.Id;

        if (!_storage.SelectedPack.ContainsKey(chatId))
        {
            await _msg.SendAndReplaceMessage(chatId, "Сначала выбери тему", ct, Keyboards.GameType);
            return;
        }

        _storage.ActiveGames.Remove(chatId);

        await _msg.SendAndReplaceMessage(chatId, "Начнём заново 👇\nВыбери количество игроков:", ct, Keyboards.PlayerCount);
    }
}

