using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class ShowHandler : ICallbackHandler
{
    private readonly IGameService _gameService;
    private readonly AppDbContext _db;
    private readonly GameSessionStorage _storage;
    private readonly ITelegramBotClient _bot;
    private readonly MessageService _msg;
    private const string SHOWMessage = "show";

    public ShowHandler(IGameService gameService, AppDbContext db, GameSessionStorage storage, ITelegramBotClient bot, MessageService msg)
    {
        _gameService = gameService;
        _db = db;
        _storage = storage;
        _bot = bot;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data == SHOWMessage;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;

        if (!_storage.ActiveGames.TryGetValue(chatId, out var gameId)) return;

        var game = await _db.GameSessions.FindAsync(new object[] { gameId }, ct);
        if (game == null) return;

        var player = _gameService.GetPlayer(game);

        var text = player.Role == Role.Spy ? "Ты ШПИОН >)" : $"Твое слово: {player.Word}";

        var playerNumber = game.CurrentPlayerIndex + 1;

        await _msg.SendAndReplaceMessage(chatId, $"Игрок {playerNumber}\n{text}", ct, Keyboards.Next);
    }
}

