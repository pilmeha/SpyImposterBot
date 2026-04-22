
using Telegram.Bot;
using Telegram.Bot.Types;

public class GameTypeHandler : ICallbackHandler
{
    private readonly GameSessionStorage _storage;
    private readonly MessageService _msg;

    private const string Prefix = "pack_";

    public GameTypeHandler(GameSessionStorage storage, MessageService msg)
    {
        _storage = storage;
        _msg = msg;
    }
    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data?.StartsWith(Prefix) == true;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;

        await Task.CompletedTask;

        var packId = long.Parse(query.Data!.Substring(Prefix.Length));

        _storage.SelectedPack[chatId] = packId;

        await _msg.SendAndReplaceMessage(chatId, MessageText.ChooseCountPlayers, ct, Keyboards.PlayerCount);
    }
}

